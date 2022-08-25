using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Doc_BE_Infrastructure.Migrations
{
    public partial class FixCertigications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Doctors_DoctorId",
                table: "Certifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Certifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Certifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Doctors_DoctorId",
                table: "Certifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_DoctorId",
                table: "Certifications");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Certifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Certifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications",
                columns: new[] { "DoctorId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Doctors_DoctorId",
                table: "Certifications",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
