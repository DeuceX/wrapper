using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Http;

namespace QuestWrap.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        public async Task<ExpandoObject> GetCurrentLevel(string url, IRequestCookieCollection cookies)
        {
            using (var fc = new FlurlClient().EnableCookies())
            {
                var cookieList = cookies.ToList();

                foreach (var cookie in cookieList)
                {
                    fc.Cookies.Add(cookie.Key, new Cookie(cookie.Key, cookie.Value));
                }

                var response = await url
                    .WithClient(fc)
                    .GetJsonAsync();

                return response;
            }
        }
    }
}
