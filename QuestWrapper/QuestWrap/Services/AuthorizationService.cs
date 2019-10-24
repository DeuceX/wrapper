using System;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using QuestWrap.Models;
using QuestWrap.Services.Interfaces;

namespace QuestWrap.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<AuthorizationResult> Authorize(AuthorizationInfo authInfo)
        {
            authInfo.GameUrl = "http://demo.en.cx/GameDetails.aspx?gid=30097";
            authInfo.Login = "stgr2";
            authInfo.Password = "password321";

            var loginUrl = "http://" + authInfo.GameUrl.Substring(7).Split('/')[0] + "/login/signin?json=1";

            // var loginUrl = "http://demo.en.cx/login/signin?json=1";

            var authResult = new AuthorizationResult();
            using (var fc = new FlurlClient().EnableCookies())
            {
                var response = await loginUrl
                    .WithClient(fc)
                    .PostUrlEncodedAsync(new {
                        authInfo.Login,
                        authInfo.Password
                    });

                var cookies = fc.Cookies;

                authResult.ResultStatus = response.StatusCode;

                if (cookies.TryGetValue("GUID", out var guid))
                    authResult.GUID = guid.Value;

                if (cookies.TryGetValue("stoken", out var stoken))
                    authResult.stoken = stoken.Value;

                if (cookies.TryGetValue("atoken", out var atoken))
                    authResult.atoken = atoken.Value;
            }

            return authResult;
        }
    }
}
