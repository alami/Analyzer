using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updDevCompByPosType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pos",
                table: "DeviceComponent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "DeviceComponent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pos",
                table: "DeviceComponent");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DeviceComponent");
        }
    }
}
