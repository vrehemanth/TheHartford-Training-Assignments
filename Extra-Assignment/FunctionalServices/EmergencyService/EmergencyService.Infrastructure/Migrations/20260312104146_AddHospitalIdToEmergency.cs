using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHospitalIdToEmergency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Emergencies",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Emergencies");
        }
    }
}
