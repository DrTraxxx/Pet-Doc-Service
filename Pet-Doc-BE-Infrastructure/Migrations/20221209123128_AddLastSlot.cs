using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pet_Doc_BE_Infrastructure.Migrations
{
    public partial class AddLastSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Schedule_StaringDay",
                table: "Doctors",
                newName: "Schedule_LastSlot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Schedule_LastSlot",
                table: "Doctors",
                newName: "Schedule_StaringDay");
        }
    }
}
