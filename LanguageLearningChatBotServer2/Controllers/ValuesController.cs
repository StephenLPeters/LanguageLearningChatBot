using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
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
            string primaryLang = Request.Query["PrimaryLanguage"];
            string secondaryLang = Request.Query["SecondaryLanguage"];
            return Program.GetNewControllerInstance(LanguageLearningChatBotCore.LanguageLookup.FindLanguage(primaryLang), LanguageLearningChatBotCore.LanguageLookup.FindLanguage(secondaryLang));
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
