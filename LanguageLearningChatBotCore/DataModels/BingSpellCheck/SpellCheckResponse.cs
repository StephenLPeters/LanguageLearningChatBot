using System.Collections.Generic;
using Newtonsoft.Json;

namespace LanguageLearningChatBotCore.DataModels.BingSpellCheck
{
    [JsonObject]
    public class SpellCheckResponse
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("flaggedTokens")]
        public List<FlaggedToken> FlaggedTokens { get; set; }
    }
}
