using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHubApi.Migrations
{
    public partial class GitHubUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Repo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Repo");
        }
    }
}
