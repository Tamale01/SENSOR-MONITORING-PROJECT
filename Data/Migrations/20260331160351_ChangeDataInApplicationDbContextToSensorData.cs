using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SensorMonitor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataInApplicationDbContextToSensorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Data",
                table: "Data");

            migrationBuilder.RenameTable(
                name: "Data",
                newName: "SensorData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorData",
                table: "SensorData",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorData",
                table: "SensorData");

            migrationBuilder.RenameTable(
                name: "SensorData",
                newName: "Data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Data",
                table: "Data",
                column: "Id");
        }
    }
}
