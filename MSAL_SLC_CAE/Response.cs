using System.Net;

namespace MSAL_SLC_CAE
{
    public class Response
    {
        public string Message { get; set; }

        public string ClaimsChallenge { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
