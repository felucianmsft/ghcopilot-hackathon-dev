using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticianApp.Migrations
{
    /// <inheritdoc />
    public partial class OpticalPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpticalPrescription",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RightEyeCorrection = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LeftEyeCorrection = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpticalPrescription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpticalPrescription_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpticalPrescription_CustomerId",
                table: "OpticalPrescription",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpticalPrescription");
        }
    }
}
