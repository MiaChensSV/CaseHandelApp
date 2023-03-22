using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseHandelApp.Migrations
{
    /// <inheritdoc />
    public partial class StatusTypeCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Status_StatusId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Cases",
                newName: "StatusTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_StatusId",
                table: "Cases",
                newName: "IX_Cases_StatusTypeCode");

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeCode",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Status_StatusTypeCode",
                table: "Cases",
                column: "StatusTypeCode",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Status_StatusTypeCode",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "StatusTypeCode",
                table: "Status");

            migrationBuilder.RenameColumn(
                name: "StatusTypeCode",
                table: "Cases",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Cases_StatusTypeCode",
                table: "Cases",
                newName: "IX_Cases_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Status_StatusId",
                table: "Cases",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
