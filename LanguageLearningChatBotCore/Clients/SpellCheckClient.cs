using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LanguageLearningChatBotCore.DataModels.BingSpellCheck;
using Newtonsoft.Json;

namespace LanguageLearningChatBotCore.Clients
{
    public class SpellCheckClient : IDisposable
    {
        static string host = "https://api.cognitive.microsoft.com";
        static string path = "/bing/v7.0/spellcheck?";
        static string params_ = "mkt=en-US&mode=proof";
        static string subscriptionKey = "4bc7dfb339264d5fa993e43cbad2d47c";

        HttpClient client { get; set; }

        public SpellCheckClient()
        {
            this.client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
        }

        public async Task<SpellCheckResponse> SpellCheck(string inputText)
        {
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("text", inputText));

            HttpResponseMessage response = new HttpResponseMessage();
            string uri = $"{host}{path}{params_}";

            using (FormUrlEncodedContent content = new FormUrlEncodedContent(values))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                response = await client.PostAsync(uri, content);
            }

            string contentString = await response.Content.ReadAsStringAsync();
            SpellCheckResponse spellCheckResponse = JsonConvert.DeserializeObject<SpellCheckResponse>(contentString);
            return spellCheckResponse;
        }

        public void Dispose()
        {
            this.client?.Dispose();
        }
    }
}
