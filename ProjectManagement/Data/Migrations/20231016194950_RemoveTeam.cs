using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class RemoveTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Companies_CompanyId_FK",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Projects_ProjectId_FK",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CompanyId_FK",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ProjectId_FK",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamId_FK",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedProjectId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AssignedProjectId",
                table: "Teams",
                column: "AssignedProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Projects_AssignedProjectId",
                table: "Teams",
                column: "AssignedProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Projects_AssignedProjectId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_AssignedProjectId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "AssignedProjectId",
                table: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Teams",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId_FK",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CompanyId_FK",
                table: "Teams",
                column: "CompanyId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ProjectId_FK",
                table: "Teams",
                column: "ProjectId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Companies_CompanyId_FK",
                table: "Teams",
                column: "CompanyId_FK",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Projects_ProjectId_FK",
                table: "Teams",
                column: "ProjectId_FK",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
