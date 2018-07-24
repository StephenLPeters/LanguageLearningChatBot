using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageLearningChatBotConsoleClient
{

    namespace WindowsApplication1
    {

        class Program
        {
            private static int controllerID = -1;


            static void Main(string[] args)
            {
                Console.WriteLine("What language would you like to chat in? <fr, es, it, en>");
                string lang = Console.ReadLine();
                Console.WriteLine("Waiting for server...");
                var getControllerIDTask = getControllerID("en", lang);
                getControllerIDTask.Wait();
                controllerID = getControllerIDTask.Result;


                string userResponse = "";
                var respondTask = Respond(userResponse);
                respondTask.Wait();
                var serverResponse = respondTask.Result;

                while (true)
                {
                    userResponse = Console.ReadLine();
                    if (userResponse.Equals("?"))
                    {
                        showTranslations(serverResponse);

                    }
                    else
                    {
                        respondTask = Respond(userResponse);
                        respondTask.Wait();
                        serverResponse = respondTask.Result;
                        //Console.WriteLine(serverResponse.Prompt.SecondaryText);
                        //Console.WriteLine(serverResponse.Response.SecondaryText);
                        writeCorrections(userResponse, serverResponse);
                    }

                }
            }
            private static void showTranslations (LanguageLearningChatBotCore.ResponseAnalysis analysis)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(analysis.Prompt.PrimaryText);
                Console.ResetColor();
            }
            private static void writeCorrections (string response, LanguageLearningChatBotCore.ResponseAnalysis analysis)
            {
                int resIndex = 0;
                foreach (LanguageLearningChatBotCore.Correction correction in analysis.Corrections)
                {
                    if (correction.Offset > 0)
                    {
                        Console.Write(response.Substring(resIndex, correction.Offset - 1));
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(correction.Corrected);
                    Console.ResetColor();

                    resIndex = correction.Offset + correction.Original.Length;
                }
                if (resIndex < response.Length - 1)
                {
                    Console.Write(response.Substring(resIndex));
                }
                Console.WriteLine();
            }

            private async static Task<int> getControllerID(string primary, string secondary)
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                using (var client = new HttpClient(handler))
                {
                    var content = "?PrimaryLanguage=" + primary + "&SecondaryLanguage=" + secondary;

                    string request = "https://localhost:5001/api/LanguageLearningChatBotServer" + content;
                    var responseBody = await client.GetStringAsync(request);

                    int id = int.Parse(responseBody);

                    Console.OutputEncoding = UnicodeEncoding.UTF8;
                    Console.WriteLine("Instance Id: " + id);
                    return id; 
                }
            }

            private async static Task<LanguageLearningChatBotCore.ResponseAnalysis> Respond(string userResponse)
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                using (var client = new HttpClient(handler))
                {

                    var values = new Dictionary<string, string>
                    {
                       { "InstanceID", controllerID.ToString() },
                       { "Response", userResponse }
                    };
                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync("https://localhost:5001/api/LanguageLearningChatBotServer", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var responseAnalysis = JsonConvert.DeserializeObject<LanguageLearningChatBotCore.ResponseAnalysis>(responseBody);
                    
                    return responseAnalysis;
                }
            }
        }
    }
}
