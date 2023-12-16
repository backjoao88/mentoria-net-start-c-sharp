using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateFirstTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Donor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    RhFactorType = table.Column<int>(type: "int", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Donor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    RhFactorType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Donation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDonor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityMl = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Donation_tbl_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "tbl_Donor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Donation_tbl_Donor_IdDonor",
                        column: x => x.IdDonor,
                        principalTable: "tbl_Donor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Donation_DonorId",
                table: "tbl_Donation",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Donation_IdDonor",
                table: "tbl_Donation",
                column: "IdDonor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Donation");

            migrationBuilder.DropTable(
                name: "tbl_Stock");

            migrationBuilder.DropTable(
                name: "tbl_Donor");
        }
    }
}
