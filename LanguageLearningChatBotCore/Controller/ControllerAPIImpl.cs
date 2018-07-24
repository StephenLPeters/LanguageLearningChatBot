using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Collections;
using System.Linq;
// NOTE: Install the Newtonsoft.Json NuGet package.
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LanguageLearningChatBotCore
{
    class Translation
    {
        public String Text { get; set; }
        public String To { get; set; }
    }

    class DetectedLang
    {
        public String Language { get; set; }
        public double Score { get; set; }
    }

    class TranslatorResponse
    {
        public DetectedLang DetectedLanguage { get; set; }
        public IList<Translation> Translations { get; set; }
    }
    public class ControllerAPIImpl
    {
        private const string host = "https://api.cognitive.microsofttranslator.com";
        private const string path = "/translate?api-version=3.0";
        // MVP - Translate to French. This will have to change to use an enum for language lookup
        private static string params_ = "&to=fr";

        private static string uri = host + path + params_;

        // NOTE: Replace this example key with a valid subscription key.
        private static string key = "fae421f860b548ecb7c5c5b04f12826a";

        private int responseCount = 0;

        public async static /*TranslationData*/void Translate(string data)
        {
            System.Object[] body = new System.Object[] { new { Text = data } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                // remove [] surrounding json response
                TranslatorResponse result = JsonConvert.DeserializeObject<TranslatorResponse>(responseBody.Substring(1, responseBody.Length-2));

                Console.OutputEncoding = UnicodeEncoding.UTF8;
                Console.WriteLine(result.Translations[0].Text);
                //return new TranslationData(data, );
            }
        }

        public ResponseAnalysis Respond(Language primary, Language secondary, string response)
        {
            responseCount++;

            var theirResponse = new TranslationData();
            theirResponse.PrimaryLanguage = primary;
            theirResponse.PrimaryText = response;
            theirResponse.SecondaryLanguage = secondary;
            theirResponse.PrimaryText = "Translated: " + response;
            var myPrompt = new TranslationData();
            myPrompt.PrimaryLanguage = primary;
            myPrompt.PrimaryText = "Response to: " + response + " - Response #" + responseCount;
            myPrompt.SecondaryLanguage = secondary;
            myPrompt.SecondaryText = "Translated Response to: " + response + " - Response #" + responseCount;

            var responseAnalysis = new ResponseAnalysis();
            responseAnalysis.Response = theirResponse;
            responseAnalysis.Prompt = myPrompt;
            responseAnalysis.Corrections = new List<Correction>();
            return responseAnalysis;
        }
    }
}