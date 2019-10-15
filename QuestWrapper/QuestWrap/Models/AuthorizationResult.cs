using System.Net;

namespace QuestWrap.Models
{
    public class AuthorizationResult
    {
        public HttpStatusCode ResultStatus { get; set; }

        public string GUID { get; set; }

        public string stoken { get; set; }

        public string atoken { get; set; }
    }
}
