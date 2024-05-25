using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMentor.Infrastructure.Migrations
{
    public partial class upimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ChapterStudies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ChapterStudies");
        }
    }
}
