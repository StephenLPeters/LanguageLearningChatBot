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
        static void Main()
        {
            LanguageLearningChatBotCore.ResponseAnalysis analysis = respond("");
            Console.WriteLine(analysis.Prompt.SecondaryText);
            LanguageLearningChatBotCore.ControllerAPIImpl.Translate("Hello World", LanguageLearningChatBotCore.Language.Spanish);
            string response = Console.ReadLine();
            //Console.WriteLine(response);

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
            LanguageLearningChatBotCore.ResponseAnalysis responseAnalysis = new LanguageLearningChatBotCore.ResponseAnalysis(prompt, response, corrections);

            return responseAnalysis;
        }
    }
}