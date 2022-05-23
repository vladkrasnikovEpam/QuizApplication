using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Infrastructure.Migrations
{
    public partial class AddStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attemps = table.Column<int>(nullable: false),
                    AverageAnswersPercent = table.Column<int>(nullable: false),
                    RegisteredUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistic");
        }
    }
}
