using System;
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

            Console.ReadLine();
        }
        static void instance(string primLang, string secondLang, string scenario){

        }
        static void respond(string userResponse){

            LanguageLearningChatBotCore.TranslationData prompt = new LanguageLearningChatBotCore.TranslationData();
            prompt.m_originalLanguage = LanguageLearningChatBotCore.Language.French;
            prompt.OriginalText = "Bonjour, ca va?";
            prompt.




        }
    }

}