using Newtonsoft.Json;

namespace LanguageLearningChatBotCore.DataModels.BingSpellCheck
{
    [JsonObject]
    public class Suggestion
    {
        [JsonProperty("suggestion")]
        public string SuggestedText { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}
