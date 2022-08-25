using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Doc_BE_Infrastructure.Migrations
{
    public partial class FixCertigications2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "WorkTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkTime",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTime", x => new { x.DoctorId, x.Id });
                    table.ForeignKey(
                        name: "FK_WorkTime_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    WorkTimeDoctorId = table.Column<int>(type: "int", nullable: false),
                    WorkTimeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableSlot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => new { x.WorkTimeDoctorId, x.WorkTimeId, x.Id });
                    table.ForeignKey(
                        name: "FK_TimeSlot_WorkTime_WorkTimeDoctorId_WorkTimeId",
                        columns: x => new { x.WorkTimeDoctorId, x.WorkTimeId },
                        principalTable: "WorkTime",
                        principalColumns: new[] { "DoctorId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
