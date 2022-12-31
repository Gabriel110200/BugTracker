using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class fixCompanyUserMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCompanies_Companies_CompanyId",
                table: "userCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_userCompanies_AspNetUsers_UserId1",
                table: "userCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCompanies",
                table: "userCompanies");

            migrationBuilder.RenameTable(
                name: "userCompanies",
                newName: "UserCompany");

            migrationBuilder.RenameIndex(
                name: "IX_userCompanies_UserId1",
                table: "UserCompany",
                newName: "IX_UserCompany_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_userCompanies_CompanyId",
                table: "UserCompany",
                newName: "IX_UserCompany_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CorporateName",
                table: "Companies",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany",
                column: "DDD");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_Companies_CompanyId",
                table: "UserCompany",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_AspNetUsers_UserId1",
                table: "UserCompany",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Companies_CompanyId",
                table: "UserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_AspNetUsers_UserId1",
                table: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UserId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "UserCompany",
                newName: "userCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompany_UserId1",
                table: "userCompanies",
                newName: "IX_userCompanies_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompany_CompanyId",
                table: "userCompanies",
                newName: "IX_userCompanies_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "CorporateName",
                table: "Companies",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCompanies",
                table: "userCompanies",
                column: "DDD");

            migrationBuilder.AddForeignKey(
                name: "FK_userCompanies_Companies_CompanyId",
                table: "userCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCompanies_AspNetUsers_UserId1",
                table: "userCompanies",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
