using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SensorMonitor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sensor_LocationId",
                table: "Sensor",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Location_LocationId",
                table: "Sensor",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Location_LocationId",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_LocationId",
                table: "Sensor");
        }
    }
}
