using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDonationDateToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DonationDate",
                table: "tbl_Donation",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DonationDate",
                table: "tbl_Donation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
