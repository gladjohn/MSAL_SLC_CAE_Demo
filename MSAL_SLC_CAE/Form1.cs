using Microsoft.Identity.Client;
using Microsoft.Identity.Client.AppConfig;
using Microsoft.IdentityModel.Abstractions;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Windows;

namespace MSAL_SLC_CAE
{
    public partial class Form1 : Form
    {
        private const string ManagedIdentityAppId = "8a7c2bc8-7041-4eb9-b49a-a70aeb68fdae";
        private const string AppIdForFicFlow = "83c136c2-14fc-457e-aa37-80168debee60";
        private const string AppTenantId = "bea21ebe-8b64-4d06-9f6d-6a889b120a7c";
        private static string targetResource = "adbd44ca-a4b1-4d30-bc40-eeb4c4e621a9";
        private string scope = $"{targetResource}/.default";
        private readonly IManagedIdentityApplication msiApp;
        string claims = null;
        IIdentityLogger identityLogger;
        AuthenticationResult? msiTokenResult;
        AuthenticationResult? appTokenResult;
        private int FetchAppTokenForFicFlowAttempts = 0;
        private int FetchTokenForMsiAttempts = 0;

        public Form1()
        {
            InitializeComponent();

            identityLogger = new IdentityLogger(msalLogs); // Pass the TextBox instance

            msiApp = ManagedIdentityApplicationBuilder
                            //.Create(ManagedIdentityId.SystemAssigned) //System Assigned 
                            .Create(ManagedIdentityId.WithUserAssignedClientId(ManagedIdentityAppId))
                            .WithExperimentalFeatures(true) //User Assigned 
                            .WithClientCapabilities(new[] { "cp1" })
                            .WithLogging(identityLogger, true)
                            .Build();

            msiTokenResult = null;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void btnFetchToken_Click(object sender, EventArgs e)
        {
            try
            {
                msiTokenResult = null;

                if (vanillaMSI.Checked == true)
                {
                    LogMessages("Starting Vanilla MSI token acquisition flow .....\n");
                    await FetchTokenForMsi(targetResource);
                }
                else if (MsiAsFicFlow.Checked == true)
                {
                    LogMessages("Starting token acquisition for 1st leg of MSI FIC flow .....\n");
                    await FetchTokenForMsi("api://AzureADTokenExchange");
                }


                Console.WriteLine("Success");
                Console.ReadLine();

                //ClaimsList.ItemsSource = new List<string>();
                //ClaimsList.ItemsSource = GetClaims(result);
            }
            catch (Exception ex)
            {
                LogMessages($"Exception: {ex}\n\n\n");
            }
        }

        private async Task FetchTokenForMsi(string target)
        {
            if (FetchTokenForMsiAttempts >= 5)
            {
                throw new InvalidOperationException("Exceeded retry attempts for FetchTokenForMsi..");
            }

            LogMessages($"Fetching token for MSI {ManagedIdentityAppId} and resource {target}.. ");
            try
            {
                // Start the progress bar
                progressBar1.Style = ProgressBarStyle.Marquee;

                AcquireTokenForManagedIdentityParameterBuilder builder = msiApp.AcquireTokenForManagedIdentity(target);

                if (claims != null)
                {
                    LogMessages($"Claims: {claims}");
                    builder.WithClaims(claims);
                }

                msiTokenResult = await builder.ExecuteAsync().ConfigureAwait(false);

                LogMessages($"Time: {DateTime.UtcNow}, CorrelationId: {msiTokenResult.CorrelationId}, Access token: {msiTokenResult.AccessToken}\n");
                FetchTokenForMsiAttempts = 0;
            }
            catch (MsalServiceException ex) when (ex.StatusCode == 400 && (ex.ErrorCode == "InvalidTenantName" || ex.ErrorCode.Contains("90002")))
            {
                FetchTokenForMsiAttempts++;
                await FetchTokenForMsi(target).ConfigureAwait(false);
                return;
            }
            catch (Exception ex)
            {
                LogMessages($"Exception: {ex}\n");
            }
            finally
            {
                // Stop the progress bar
                progressBar1.Style = ProgressBarStyle.Continuous;
            }
        }

        private async void FetchAppTokenClick(object sender, EventArgs e)
        {
            await FetchAppTokenForFicFlow();
        }

        private async Task FetchAppTokenForFicFlow()
        {
            // Assume MSI token is available in result.
            LogMessages($"Fetching app token for clientId: {AppIdForFicFlow} and scope: {scope}.. ");

            if (FetchAppTokenForFicFlowAttempts >= 5)
            {
                throw new InvalidOperationException("Exceeded retry attempts for FetchAppTokenForFicFlow..");
            }

            try
            {
                // Start the progress bar
                progressBar1.Style = ProgressBarStyle.Marquee;

                IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(AppIdForFicFlow)
                    .WithClientAssertion(msiTokenResult.AccessToken)
                    .WithAzureRegion()
                    .WithTenantId(AppTenantId)
                    .WithClientCapabilities(new[] { "cp1" }).Build();

                AcquireTokenForClientParameterBuilder builder = app.AcquireTokenForClient(new List<string>() { scope }).WithExtraQueryParameters("slice=testslice");

                if (claims != null)
                {
                    LogMessages($"Claims: {claims}");
                    builder.WithClaims(claims);
                }

                appTokenResult = await builder.ExecuteAsync().ConfigureAwait(false);

                LogMessages($"Time: {DateTime.UtcNow}, CorrelationId: {appTokenResult.CorrelationId}, Access token: {appTokenResult.AccessToken}\n");
                FetchAppTokenForFicFlowAttempts = 0;
            }
            catch (MsalServiceException ex) when (ex.StatusCode == 400 && (ex.ErrorCode == "InvalidTenantName" || ex.ErrorCode.Contains("90002")))
            {
                FetchAppTokenForFicFlowAttempts++;
                await FetchAppTokenForFicFlow().ConfigureAwait(false);
                return;
            }
            catch (Exception ex)
            {
                LogMessages($"Exception: {ex}\n");
            }
            finally
            {
                // Stop the progress bar
                progressBar1.Style = ProgressBarStyle.Continuous;
            }
        }

        private void FetchResource(object sender, EventArgs e)
        {
            if (vanillaMSI.Checked && msiTokenResult == null)
            {
                LogMessages("Please acquire token first before fetching resource");
                return;
            }
            else if (MsiAsFicFlow.Checked && appTokenResult == null)
            {
                LogMessages("Please acquire token first before fetching resource");
                return;
            }

            try
            {
                Guid correlationId = Guid.NewGuid();

                LogMessages($"[{DateTime.Now}]: Calling resource api with correlationid {correlationId} \n");

                var response = this.CallDownstreamService(correlationId, vanillaMSI.Checked);
                var responseContent = new Response()
                {
                    StatusCode = response.StatusCode,
                    Message = "data retrieved",
                };

                if (responseContent.StatusCode == HttpStatusCode.OK)
                {
                    claims = null;
                    LogMessages($"Fetch Resource API Successful. Status code {response.StatusCode}\n");
                }
                else if (responseContent.StatusCode == HttpStatusCode.Unauthorized)
                {
                    string claimsChallenge = ParseWwwAuthenticateAndReturnClaims(response.Headers.GetValues("www-authenticate").First());

                    string claimsChallengeDecoded = Encoding.UTF8.GetString(Convert.FromBase64String(claimsChallenge));
                    LogMessages($"Fetch Resource API Failed with Status 401 + ClaimsChallenge: {claimsChallengeDecoded} \n");

                    claims = claimsChallengeDecoded;
                }
                else
                {
                    LogMessages($"Fetch Resource API Failed with Status :{responseContent.StatusCode} and Exception : {response.Content.ReadAsStringAsync().Result}\n");
                }
            }
            catch (Exception e1)
            {
                LogMessages($"Fetch Resource API throws exception: {e1}\n");
            }
            finally
            {
            }
        }

        private HttpResponseMessage CallDownstreamService(Guid correlationId, bool isMsiToken)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:5000/authorize")
            };

            var eventData = new Dictionary<string, object>()
            {
                { nameof(correlationId), correlationId },
                {
                    "request",
                    new Dictionary<string, object>()
                    {
                        { "method", httpRequestMessage.Method.ToString() },
                        { "uri", httpRequestMessage.RequestUri.ToString() }
                    }
                }
            };

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: isMsiToken ? msiTokenResult!.AccessToken : appTokenResult!.AccessToken);

            httpRequestMessage.Headers.Add("CorrelationId", correlationId.ToString());

            Exception exception = null;
            HttpResponseMessage httpResponseMessage;

            try
            {
                var httpclient = new HttpClient();
                httpResponseMessage = httpclient.Send(httpRequestMessage);

                if (!httpResponseMessage.Headers.TryGetValues("origin", out IEnumerable<string> originValues))
                {
                    throw new ArgumentException($"Response did not contain the required origin header");
                }

                var responseContent = new Response()
                {
                    StatusCode = httpResponseMessage.StatusCode,
                    Message = "data retrieved",
                };

                eventData.Add(
                    key: "response",
                    value: responseContent);

                return httpResponseMessage;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
        }

        private string ParseWwwAuthenticateAndReturnClaims(string wwwAuthenticate)
        {
            List<string> headerPairs = SplitWithQuotes(wwwAuthenticate, ',');
            foreach (string pair in headerPairs)
            {
                List<string> keyValue = SplitWithQuotes(pair, '=');
                if (keyValue.Count == 2 && string.Equals(keyValue[0].Trim(), "claims", StringComparison.OrdinalIgnoreCase))
                {
                    return keyValue[1].Trim().Replace("\"", "");
                }
            }

            return string.Empty;
        }

        internal static List<string> SplitWithQuotes(string input, char delimiter)
        {
            List<string> items = new List<string>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return items;
            }

            int startIndex = 0;
            bool insideString = false;
            string item;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == delimiter && !insideString)
                {
                    item = input.Substring(startIndex, i - startIndex);
                    if (!string.IsNullOrWhiteSpace(item.Trim()))
                    {
                        items.Add(item);
                    }

                    startIndex = i + 1;
                }
                else if (input[i] == '"')
                {
                    insideString = !insideString;
                }
            }

            item = input.Substring(startIndex);
            if (!string.IsNullOrWhiteSpace(item.Trim()))
            {
                items.Add(item);
            }

            return items;
        }

        public void LogMessages(string logMessage)
        {
            // Append log message to the TextBox
            txtBoxLogs.AppendText(logMessage + "\n\n");
        }

        private static IEnumerable<Claim> GetClaims(AuthenticationResult result)
        {
            var jwt = result.AccessToken;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            List<Claim> formattedClaims = new List<Claim>();
            foreach (Claim cl in token.Claims)
            {
                switch (cl.Type)
                {
                    case "iat":
                    case "nbf":
                    case "exp":
                        string dt = ConvertEpochToString(Double.Parse(cl.Value, CultureInfo.InvariantCulture));
                        formattedClaims.Add(new Claim(cl.Type, dt));
                        break;
                    case "aud":
                    case "appid":
                    case "azp":
                    case "xms_az_rid":
                    case "xms_cc":
                    case "xms_ssm":
                    case "xms_rd":
                    case "capolids_latebind":
                        formattedClaims.Add(new Claim(cl.Type, cl.Value));
                        break;
                    default:
                        break;
                }
            }
            return formattedClaims;
        }

        private static string ConvertEpochToString(double epochTime)
        {
            DateTime dt = new DateTime(1970, 1, 1).AddSeconds(epochTime);
            return dt.ToString("u");
        }
    }

    class IdentityLogger : IIdentityLogger
    {
        private readonly TextBox _textBox;

        public EventLogLevel MinLogLevel { get; }

        public IdentityLogger(TextBox textBox)
        {
            _textBox = textBox;
            MinLogLevel = EventLogLevel.Verbose;
        }

        public bool IsEnabled(EventLogLevel eventLogLevel)
        {
            return eventLogLevel <= MinLogLevel;
        }

        public void Log(LogEntry entry)
        {
            // Log Message to Console
            Console.WriteLine(entry.Message);

            // Log Message to TextBox
            LogToTextBox(entry.Message);
        }

        private void LogToTextBox(string? message)
        {
            if (_textBox.InvokeRequired)
            {
                _textBox.Invoke(new Action(() => LogToTextBox(message)));
            }
            else
            {
                _textBox.AppendText(message + "\n\n");
            }
        }
    }

}