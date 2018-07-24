using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LanguageLearningChatBotServer2.Controllers
{
    [Route("api/LanguageLearningChatBotServer")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<int> Get()
        {
            return Program.GetNewControllerInstance(LanguageLearningChatBotCore.Language.English, LanguageLearningChatBotCore.Language.French);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post()
        {
            var responseAnalysis = Program.Respond(int.Parse(Request.Form["InstanceID"]), Request.Form["Response"]);
            
            return JsonConvert.SerializeObject(responseAnalysis);
        }

    }
}
