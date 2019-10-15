using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestWrap.Models;
using QuestWrap.Services.Interfaces;

namespace QuestWrap.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("authorization/authorize/")]
        public async Task<IActionResult> Authorize([FromBody] AuthorizationInfo authInfo)
        {
            var authResult = await authorizationService.Authorize(authInfo);

            if (authResult.ResultStatus == HttpStatusCode.OK)
            {
                var option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(15)
                };

                Response.Cookies.Append("GUID", authResult.GUID, option);
                Response.Cookies.Append("atoken", authResult.atoken, option);
                Response.Cookies.Append("stoken", authResult.stoken, option);
                Response.Cookies.Append("gameUrl", authInfo.GameUrl, option);

                return Ok(authResult.ResultStatus);
            }

            return BadRequest("Failed");
        }
    }
}