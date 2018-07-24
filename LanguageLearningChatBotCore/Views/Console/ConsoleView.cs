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
            /*LanguageLearningChatBotCore.ResponseAnalysis analysis = respond("");
            Console.WriteLine(analysis.Prompt.SecondaryText);

            if (args.Length > 0)
            {
                if (args[0] == "-ut")
                {
                    RunUnitTests();
                }
                if (args[0] == "-dbp")
                {
                    PrintDatabase();
                }
                if (args[0] == "-dbc")
                {
                    ClearDatabase();
                }
                if (args[0] == "-dbi")
                {
                    InitializeDatabase();
                }
            }
            string response = Console.ReadLine();
            Console.WriteLine(response);
            */
        }

        /*


        static void ClearDatabase()
        {
            using (var db = new LanguageLearningChatBotCore.ScenarioContext())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Clearing the database...");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var scenario in db.Scenarios)
                {
                    db.Scenarios.Remove(scenario);
                }
                foreach (var prompt in db.Prompts)
                {
                    db.Prompts.Remove(prompt);
                }
                db.SaveChanges();
            }
        }
        static void PrintDatabase()
        {
            using (var db = new LanguageLearningChatBotCore.ScenarioContext())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All Scenarios in database:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var scenario in db.Scenarios)
                {
                    Console.WriteLine(" - {0} - {1}", scenario.Title, scenario.ScenarioID);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All Prompts in database:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var prompt in db.Prompts)
                {
                    Console.WriteLine("Scenario {0} Response {1} Option {2}: {3} - {4} ",
                     prompt.ScenarioID, prompt.ResponseNumber, prompt.OptionNumber, prompt.PromptText, prompt.PromptID);
                }
            }

        }
        static void InitializeDatabase()
        {
            using (var db = new LanguageLearningChatBotCore.ScenarioContext())
            {
                var restrauntScenario = new LanguageLearningChatBotCore.Scenario {ScenarioID = 0, Title = "Restraunt"};
                db.Scenarios.Add(restrauntScenario);
                db.SaveChanges();
                db.Prompts.Add(new LanguageLearningChatBotCore.Prompt{
                    Scenario = restrauntScenario,
                    ScenarioID = restrauntScenario.ScenarioID,
                    ResponseNumber = 0,
                    OptionNumber = 0,
                    PromptText = "Hey there! Welcome to my restraunt, how many in your party?",
                });
                db.Prompts.Add(new LanguageLearningChatBotCore.Prompt{
                    Scenario = restrauntScenario,
                    ScenarioID = restrauntScenario.ScenarioID,
                    ResponseNumber = 1,
                    OptionNumber = 0,
                    PromptText = "Awesome! You can sit right over there, Sam will be right with you.",
                });
                db.Prompts.Add(new LanguageLearningChatBotCore.Prompt{
                    Scenario = restrauntScenario,
                    ScenarioID = restrauntScenario.ScenarioID,
                    ResponseNumber = 2,
                    OptionNumber = 0,
                    PromptText = "Hello! What brings you out tonight?",
                });
                db.Prompts.Add(new LanguageLearningChatBotCore.Prompt{
                    Scenario = restrauntScenario,
                    ScenarioID = restrauntScenario.ScenarioID,
                    ResponseNumber = 3,
                    OptionNumber = 0,
                    PromptText = "That sounds great, well can I get you started with some drinks?",
                });
                db.Prompts.Add(new LanguageLearningChatBotCore.Prompt{
                    Scenario = restrauntScenario,
                    ScenarioID = restrauntScenario.ScenarioID,
                    ResponseNumber = 4,
                    OptionNumber = 0,
                    PromptText = "Perfect, I'll be right back with those.",
                });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);


                Console.WriteLine();
                Console.WriteLine("All Scenarios in database:");
                foreach (var scenario in db.Scenarios)
                {
                    Console.WriteLine(" - {0} - {1}", scenario.Title, scenario.ScenarioID);
                }
            }
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
        }*/
    }
}