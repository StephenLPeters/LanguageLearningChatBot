using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
// NOTE: Install the Newtonsoft.Json NuGet package.
using Newtonsoft.Json;

namespace TranslatorTextQuickStart
{
    class ConsoleView
    {
        static string primLang = "en-us";
        static string secondLang = "fr-fr";
        static string scenario = "Restaurant";
        static void Main(string[] args)
        {
            instance(primLang, secondLang, scenario);
            LanguageLearningChatBotCore.ResponseAnalysis analysis = respond("");
            Console.WriteLine(analysis.Prompt.m_secondaryText);
            string response = Console.ReadLine();
            Console.WriteLine(response);
        }
        static void instance(string primLang, string secondLang, string scenario){

        }
        static LanguageLearningChatBotCore.ResponseAnalysis respond(string userResponse){

            LanguageLearningChatBotCore.TranslationData prompt = new LanguageLearningChatBotCore.TranslationData();
            prompt.m_secondaryLanguage = LanguageLearningChatBotCore.Language.French;
            prompt.m_secondaryText = "Bonjour, ca va?";
            prompt.m_primaryLanguage = LanguageLearningChatBotCore.Language.English;
            prompt.m_primaryText = "Hello, how are you?";

            LanguageLearningChatBotCore.TranslationData response = new LanguageLearningChatBotCore.TranslationData();
            response.m_secondaryLanguage = LanguageLearningChatBotCore.Language.French;
            response.m_secondaryText = "Tres brien, merci";
            response.m_primaryLanguage = LanguageLearningChatBotCore.Language.English;
            response.m_primaryText = "Very well, thank you";

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