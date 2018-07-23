using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LanguageLearningChatBotCore.DataModels.BingSpellCheck
{
    [JsonObject]
    class FlaggedToken
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("suggestions")]
        public List<Suggestion> Suggestions { get; set; }
    }
}
