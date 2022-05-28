using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthGroup.Data.Migrations
{
    public partial class youthDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Access",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "SiteUsers");

            migrationBuilder.AddColumn<string>(
                name: "AccOwnerId",
                table: "SiteUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteUsers",
                table: "SiteUsers",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUsers_AccOwnerId",
                table: "SiteUsers",
                column: "AccOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteUsers_AspNetUsers_AccOwnerId",
                table: "SiteUsers",
                column: "AccOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteUsers_AspNetUsers_AccOwnerId",
                table: "SiteUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteUsers",
                table: "SiteUsers");

            migrationBuilder.DropIndex(
                name: "IX_SiteUsers_AccOwnerId",
                table: "SiteUsers");

            migrationBuilder.DropColumn(
                name: "AccOwnerId",
                table: "SiteUsers");

            migrationBuilder.RenameTable(
                name: "SiteUsers",
                newName: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Access",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");
        }
    }
}
