using Microsoft.EntityFrameworkCore.Migrations;

namespace Neusta.CompanyService.Database.Migrations
{
    public partial class CompanyServiceMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompanyAttribute",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "CompanyAttribute",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "CompanyAttribute",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Company",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "CompanyAttribute");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "CompanyAttribute");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompanyAttribute",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
