using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuestWrap.Models;

namespace QuestWrap.Services.Interfaces
{
    public interface IGameService
    {
        Task<ExpandoObject> GetCurrentLevel(IRequestCookieCollection cookies);
    }
}
