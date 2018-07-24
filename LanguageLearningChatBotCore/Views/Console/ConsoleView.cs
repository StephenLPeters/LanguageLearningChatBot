using System;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
// NOTE: Install the Newtonsoft.Json NuGet package.
using Newtonsoft.Json;

namespace TranslatorTextQuickStart
{
    class ConsoleView
    {
        static void Main(string[] args)
        {
            LanguageLearningChatBotCore.ResponseAnalysis analysis = respond("");
            Console.WriteLine(analysis.Prompt.SecondaryText);

            if (args.Length > 0)
            {
                if (args[0] == "-ut")
                {
                    RunUnitTests();
                }
            }
            string response = Console.ReadLine();
            Console.WriteLine(response);

        }

        static void RunUnitTests()
        {
            RunTranslateUnitTests();
        }

        static void RunTranslateUnitTests()
        {
            //Task<TranslationData> task1 = Task<TranslationData>.Factory.StartNew();
            LanguageLearningChatBotCore.TranslationData result = LanguageLearningChatBotCore.ControllerAPIImpl.Translate("Hello World", LanguageLearningChatBotCore.Language.Spanish).Result;
            Console.WriteLine("Running Translate Unit Test - hit Enter to continue");
            Console.ReadLine();
            if (result.PrimaryLanguage != LanguageLearningChatBotCore.Language.English
            || result.SecondaryLanguage != LanguageLearningChatBotCore.Language.Spanish
            || result.PrimaryText != "Hello World"
            || result.SecondaryText != "Hola mundo" )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Translate failed unit test");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Translate passed unit test");
                Console.ResetColor();
            }
        }

        static LanguageLearningChatBotCore.ResponseAnalysis respond(string userResponse){

            LanguageLearningChatBotCore.TranslationData prompt = new LanguageLearningChatBotCore.TranslationData();
            prompt.SecondaryLanguage = LanguageLearningChatBotCore.Language.French;
            prompt.SecondaryText = "Bonjour, ca va?";
            prompt.PrimaryLanguage = LanguageLearningChatBotCore.Language.English;
            prompt.PrimaryText = "Hello, how are you?";

            LanguageLearningChatBotCore.TranslationData response = new LanguageLearningChatBotCore.TranslationData();
            response.SecondaryLanguage = LanguageLearningChatBotCore.Language.French;
            response.SecondaryText = "Tres brien, merci";
            response.PrimaryLanguage = LanguageLearningChatBotCore.Language.English;
            response.PrimaryText = "Very well, thank you";

            LanguageLearningChatBotCore.Correction correction = new LanguageLearningChatBotCore.Correction();
            correction.Original = "hi";
            correction.Offset = 1;
            correction.Corrected = "bingo bango";

            List<LanguageLearningChatBotCore.Correction> corrections = new List<LanguageLearningChatBotCore.Correction>();
            corrections.Add(correction);
            LanguageLearningChatBotCore.ResponseAnalysis responseAnalysis = new LanguageLearningChatBotCore.ResponseAnalysis();
            responseAnalysis.Prompt = prompt;
            responseAnalysis.Response = response;
            responseAnalysis.Corrections = corrections;

            return responseAnalysis;
        }
    }
}