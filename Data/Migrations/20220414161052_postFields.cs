using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthGroup.Data.Migrations
{
    public partial class postFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");
        }
    }
}
