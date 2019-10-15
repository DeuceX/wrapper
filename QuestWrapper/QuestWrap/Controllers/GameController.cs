using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestWrap.Services.Interfaces;

namespace QuestWrap.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        [Route("game/currentlevel")]
        public async Task<OkObjectResult> CurrentLevel()
        {
            var gameEngineLevel = await gameService.GetCurrentLevel(Request.Cookies);
            var jsonObject = JsonConvert.SerializeObject(gameEngineLevel);

            return Ok(new { jsonObject });
        }
    }
}