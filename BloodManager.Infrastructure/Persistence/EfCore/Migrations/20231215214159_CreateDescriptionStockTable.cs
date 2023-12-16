using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateDescriptionStockTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tbl_Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tbl_Stock");
        }
    }
}
