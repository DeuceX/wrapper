using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuestWrap.Helpers;
using QuestWrap.Models;
using QuestWrap.Services.Interfaces;

namespace QuestWrap.Services
{
    public class GameService : IGameService
    {
        private readonly IHttpHelper httpHelper;

        public GameService(IHttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }

        public Task<ExpandoObject> GetCurrentLevel(IRequestCookieCollection cookies)
        {
            cookies.TryGetValue("gameUrl", out var url);

            url = url.ToLower();

            var gameId = url.Split("gid=")[1];
            var domainUrl = url.Split("gamedetails")[0];

            var currentLevelUrl = $"{domainUrl}GameEngines/Encounter/Play/{gameId}?json=1";

            return httpHelper.GetCurrentLevel(currentLevelUrl, cookies);
        }
    }
}
