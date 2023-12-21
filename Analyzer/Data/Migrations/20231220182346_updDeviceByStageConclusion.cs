using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updDeviceByStageConclusion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DiffResult",
                table: "Device",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCommentsAz",
                table: "Device",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "Device",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalAll",
                table: "Device",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Сonclusion",
                table: "Device",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Visible",
                table: "Component",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiffResult",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "OtherCommentsAz",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "TotalAll",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "Сonclusion",
                table: "Device");

            migrationBuilder.AlterColumn<bool>(
                name: "Visible",
                table: "Component",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
