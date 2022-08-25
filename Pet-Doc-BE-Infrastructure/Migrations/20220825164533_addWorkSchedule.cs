using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Doc_BE_Infrastructure.Migrations
{
    public partial class addWorkSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstSlot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailySlots = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDay_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDay_DoctorId",
                table: "WorkingDay",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingDay");
        }
    }
}
