using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageLearningChatBotCore.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    ScenarioID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.ScenarioID);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    PromptID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResponseNumber = table.Column<int>(nullable: false),
                    OptionNumber = table.Column<int>(nullable: false),
                    PromptText = table.Column<string>(nullable: true),
                    ScenarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.PromptID);
                    table.ForeignKey(
                        name: "FK_Prompts_Scenarios_ScenarioID",
                        column: x => x.ScenarioID,
                        principalTable: "Scenarios",
                        principalColumn: "ScenarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_ScenarioID",
                table: "Prompts",
                column: "ScenarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prompts");

            migrationBuilder.DropTable(
                name: "Scenarios");
        }
    }
}
