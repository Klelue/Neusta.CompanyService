using Microsoft.EntityFrameworkCore.Migrations;

namespace Neusta.CompanyService.Database.Migrations
{
    public partial class CompanyServiceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAttributeValue",
                columns: table => new
                {
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: false),
                    CompanyAttributeId = table.Column<long>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAttributeValue", x => new { x.CompanyAttributeId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanyAttributeValue_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAttributeValue_CompanyAttribute_CompanyAttributeId",
                        column: x => x.CompanyAttributeId,
                        principalTable: "CompanyAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAttributeValue_CompanyId",
                table: "CompanyAttributeValue",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAttributeValue");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "CompanyAttribute");
        }
    }
}
