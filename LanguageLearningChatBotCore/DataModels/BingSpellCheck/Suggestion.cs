using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LanguageLearningChatBotCore.DataModels.BingSpellCheck
{
    [JsonObject]
    class Suggestion
    {
        [JsonProperty("suggestion")]
        public string SuggestedText { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}
