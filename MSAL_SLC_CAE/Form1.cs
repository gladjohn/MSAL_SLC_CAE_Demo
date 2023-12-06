using Microsoft.Identity.Client;
using Microsoft.Identity.Client.AppConfig;
using Microsoft.IdentityModel.Abstractions;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        readonly string claims = null;
        IIdentityLogger identityLogger;
        AuthenticationResult? result;

        public Form1()
        {
            InitializeComponent();

            identityLogger = new IdentityLogger(msalLogs); // Pass the TextBox instance

            msiApp = ManagedIdentityApplicationBuilder
                            //.Create(ManagedIdentityId.SystemAssigned) //System Assigned 
                            .Create(ManagedIdentityId.WithUserAssignedClientId(ManagedIdentityAppId))
                            .WithExperimentalFeatures(true) //User Assigned 
                                                            //.WithClientCapabilities(new[] { "cp1" })
                            .WithLogging(identityLogger, true)
                            .Build();

            result = null;
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
                result = null;

                if (vanillaMSI.Checked == true)
                {
                    LogMessages("Starting token acquisition for MSI flow .....\n\n\n");
                    try
                    {
                        // Start the progress bar
                        progressBar1.Style = ProgressBarStyle.Marquee;

                        AcquireTokenForManagedIdentityParameterBuilder builder = msiApp.AcquireTokenForManagedIdentity(targetResource);

                        if (claims != null)
                        {
                            LogMessages($"Claims: {claims}");
                            //builder.WithClaims(claims);
                        }

                        result = await builder.ExecuteAsync().ConfigureAwait(false);

                        LogMessages($"Access token: {result.AccessToken}\n\n\n");
                        LogMessages($"Time: {DateTime.UtcNow}, CorrelationId: {result.CorrelationId}, Access token: {result.AccessToken}");
                    }
                    catch (MsalServiceException ex)
                    {
                        Console.WriteLine(ex.ErrorCode);
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        Console.ReadLine();
                    }
                    finally
                    {
                        // Stop the progress bar
                        progressBar1.Style = ProgressBarStyle.Continuous;
                    }
                }
                //else if (MsiFicRequest.IsChecked == true)
                //{
                //    LogMessages("Starting token acquisition for 2 legged FIC flow .....\n\n\n");
                //    Perform2LeggedFicFlow();
                //}


                Console.WriteLine("Success");
                Console.ReadLine();

                //ClaimsList.ItemsSource = new List<string>();
                //ClaimsList.ItemsSource = GetClaims(result);
                //LogMessages(GetClaims(result));
            }
            catch (Exception ex)
            {
                LogMessages($"Exception: {ex}\n\n\n");
            }
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