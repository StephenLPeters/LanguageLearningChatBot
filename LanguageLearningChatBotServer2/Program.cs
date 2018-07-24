using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LanguageLearningChatBotServer2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static int GetNewControllerInstance(LanguageLearningChatBotCore.Language primary, LanguageLearningChatBotCore.Language secondary)
        {
            return LanguageLearningChatBotCore.ControllerSingleton.GetInstanceID(primary, secondary);
        }

        public static LanguageLearningChatBotCore.ResponseAnalysis Respond(int id, string data)
        {
            return LanguageLearningChatBotCore.ControllerSingleton.Respond(id, data);
        }
    }
}
