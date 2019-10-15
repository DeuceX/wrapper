using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QuestWrap.Helpers
{
    public interface IHttpHelper
    {
        Task<ExpandoObject> GetCurrentLevel(string url, IRequestCookieCollection cookies);
    }
}
