using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class fixCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorporateName",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CorporateName",
                table: "Companies");
        }
    }
}
