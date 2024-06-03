using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Data.Migrations
{
    public partial class AddTicketRelatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Tickets");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickets",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpectedBehavior",
                table: "Tickets",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Tickets",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservableBehavior",
                table: "Tickets",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StepsToReproduce",
                table: "Tickets",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketCategoryId_FK",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Visibility",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TicketCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCategoryId_FK",
                table: "Tickets",
                column: "TicketCategoryId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketCategories_TicketCategoryId_FK",
                table: "Tickets",
                column: "TicketCategoryId_FK",
                principalTable: "TicketCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketCategories_TicketCategoryId_FK",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketCategoryId_FK",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ExpectedBehavior",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ObservableBehavior",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StepsToReproduce",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketCategoryId_FK",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Tickets",
                type: "varchar(30)",
                nullable: true);
        }
    }
}
