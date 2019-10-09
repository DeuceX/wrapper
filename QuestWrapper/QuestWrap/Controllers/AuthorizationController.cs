using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuestWrap.Models;

namespace QuestWrap.Controllers
{
    public class AuthorizationController : Controller
    {
        [HttpPost]
        [Route("authorization/authorize/")]
        public ActionResult Authorize([FromBody] AuthorizationInfo authInfo)
        {
            return Ok(123);
        }

        // GET: Authorization/Edit/5
        [HttpGet]
        [Route("authorization/edit/{id}")]
        public IEnumerable Edit(int id)
        {
            return new List<int>() {1, 2, 3, 4};
        }
    }
}