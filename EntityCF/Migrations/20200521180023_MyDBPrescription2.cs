using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityCF.Migrations
{
    public partial class MyDBPrescription2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedicament",
                table: "Prescription_Medicament",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPrescription",
                table: "Prescription_Medicament",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropColumn(
                name: "IdPrescription",
                table: "Prescription_Medicament");
        }
    }
}
