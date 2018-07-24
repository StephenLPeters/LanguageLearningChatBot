using System.Collections.Generic;
using Newtonsoft.Json;

namespace LanguageLearningChatBotCore.DataModels
{
    [JsonObject]
    public class Translation
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
    }

    [JsonObject]
    public class DetectedLang
    {
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
    }

    [JsonObject]
    public class TranslatorResponse
    {
        [JsonProperty("detectedLanguage")]
        public DetectedLang DetectedLanguage { get; set; }
        [JsonProperty("translations")]
        public IList<Translation> Translations { get; set; }
    }
}