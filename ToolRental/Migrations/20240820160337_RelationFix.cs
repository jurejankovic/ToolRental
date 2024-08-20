using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolRental.Migrations
{
    /// <inheritdoc />
    public partial class RelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Renters_ToolReservation_ToolReservationId",
                table: "Renters");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_ToolReservation_ToolReservationId",
                table: "Tool");

            migrationBuilder.DropIndex(
                name: "IX_Tool_ToolReservationId",
                table: "Tool");

            migrationBuilder.DropIndex(
                name: "IX_Renters_ToolReservationId",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "ToolReservationId",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "ToolReservationId",
                table: "Renters");

            migrationBuilder.AddColumn<int>(
                name: "RentedToolId",
                table: "ToolReservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToolRenterId",
                table: "ToolReservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToolReservation_RentedToolId",
                table: "ToolReservation",
                column: "RentedToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolReservation_ToolRenterId",
                table: "ToolReservation",
                column: "ToolRenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToolReservation_Renters_ToolRenterId",
                table: "ToolReservation",
                column: "ToolRenterId",
                principalTable: "Renters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToolReservation_Tool_RentedToolId",
                table: "ToolReservation",
                column: "RentedToolId",
                principalTable: "Tool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolReservation_Renters_ToolRenterId",
                table: "ToolReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ToolReservation_Tool_RentedToolId",
                table: "ToolReservation");

            migrationBuilder.DropIndex(
                name: "IX_ToolReservation_RentedToolId",
                table: "ToolReservation");

            migrationBuilder.DropIndex(
                name: "IX_ToolReservation_ToolRenterId",
                table: "ToolReservation");

            migrationBuilder.DropColumn(
                name: "RentedToolId",
                table: "ToolReservation");

            migrationBuilder.DropColumn(
                name: "ToolRenterId",
                table: "ToolReservation");

            migrationBuilder.AddColumn<int>(
                name: "ToolReservationId",
                table: "Tool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToolReservationId",
                table: "Renters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tool_ToolReservationId",
                table: "Tool",
                column: "ToolReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_ToolReservationId",
                table: "Renters",
                column: "ToolReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Renters_ToolReservation_ToolReservationId",
                table: "Renters",
                column: "ToolReservationId",
                principalTable: "ToolReservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_ToolReservation_ToolReservationId",
                table: "Tool",
                column: "ToolReservationId",
                principalTable: "ToolReservation",
                principalColumn: "Id");
        }
    }
}
