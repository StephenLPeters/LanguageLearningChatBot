using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    public class ScenarioContext : DbContext
    {
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Prompt> Prompts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=scenarios.db");
        }
    }

    public class Scenario
    {
        public int ScenarioID { get; set; }
        public string Title { get; set; }
        public List<Prompt> Prompts { get; set; }
    }

    public class Prompt
    {
        public int PromptID { get; set; }
        public int ResponseNumber { get; set; }
        public int OptionNumber { get; set; }
        public string PromptText { get; set; }

        public int ScenarioID { get; set; }
        public Scenario Scenario { get; set; }
    }
}