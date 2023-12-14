using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updComponentVisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Component",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Component");
        }
    }
}
