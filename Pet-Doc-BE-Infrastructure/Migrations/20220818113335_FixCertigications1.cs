using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Doc_BE_Infrastructure.Migrations
{
    public partial class FixCertigications1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Doctors_DoctorId",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_DoctorId",
                table: "Certifications");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Certifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Certifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_DoctorId",
                table: "Certifications",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Doctors_DoctorId",
                table: "Certifications",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
