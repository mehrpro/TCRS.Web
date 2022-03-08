using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCRS.Web.Migrations
{
    public partial class AddAcademicYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterID_FK",
                table: "ClassRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    YearID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearTitle = table.Column<string>(maxLength: 100, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterTitle = table.Column<string>(maxLength: 100, nullable: false),
                    AcademicYearID_FK = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterID);
                    table.ForeignKey(
                        name: "FK_Semesters_AcademicYears_AcademicYearID_FK",
                        column: x => x.AcademicYearID_FK,
                        principalTable: "AcademicYears",
                        principalColumn: "YearID");
                });

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "YearID", "EndTime", "IsActive", "StartTime", "YearTitle" },
                values: new object[] { 1, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2021, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "1400-1401" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonID", "IsActive", "LessonCode", "LessonTitle", "NumberOfCourseUnits", "PresentationCode" },
                values: new object[] { 1, true, "112233", "مبانی برنامه نویسی وب", (byte)2, "332211" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonID", "IsActive", "LessonCode", "LessonTitle", "NumberOfCourseUnits", "PresentationCode" },
                values: new object[] { 2, true, "225563", "معارف اسلامی", (byte)2, "958574" });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "AcademicYearID_FK", "EndTime", "IsActive", "SemesterTitle", "StartTime" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "نیم سال اول", new DateTime(2021, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "SemesterID", "AcademicYearID_FK", "EndTime", "IsActive", "SemesterTitle", "StartTime" },
                values: new object[] { 2, 1, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "نیم سال دوم", new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_SemesterID_FK",
                table: "ClassRooms",
                column: "SemesterID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_AcademicYearID_FK",
                table: "Semesters",
                column: "AcademicYearID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Semesters_SemesterID_FK",
                table: "ClassRooms",
                column: "SemesterID_FK",
                principalTable: "Semesters",
                principalColumn: "SemesterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Semesters_SemesterID_FK",
                table: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_SemesterID_FK",
                table: "ClassRooms");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SemesterID_FK",
                table: "ClassRooms");
        }
    }
}
