using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace LanguageLearningChatBotCore.DataModels.BingSpellCheck
{
    [JsonObject]
    class SpellCheckResponse
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("flaggedTokens")]
        public List<FlaggedToken> FlaggedTokens { get; set; }
    }
}
