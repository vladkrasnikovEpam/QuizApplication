using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Infrastructure.Migrations
{
    public partial class AddAnswerFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "Answer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correct",
                table: "Answer");
        }
    }
}
