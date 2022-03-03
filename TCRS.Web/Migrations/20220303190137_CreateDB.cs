using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCRS.Web.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    RoleID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FName = table.Column<string>(maxLength: 100, nullable: true),
                    LName = table.Column<string>(maxLength: 100, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 11, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ClassTimeTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTimeTypeTitle = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTimeTypes", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "ClassTypes",
                columns: table => new
                {
                    ClassTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTypeTitle = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTypes", x => x.ClassTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonTitle = table.Column<string>(maxLength: 150, nullable: false),
                    NumberOfCourseUnits = table.Column<byte>(nullable: false),
                    LessonCode = table.Column<string>(maxLength: 50, nullable: true),
                    PresentationCode = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AppRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID_FK = table.Column<string>(nullable: false),
                    LessonID_FK = table.Column<int>(nullable: false),
                    StudentNumber = table.Column<short>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_ClassRooms_Lessons_LessonID_FK",
                        column: x => x.LessonID_FK,
                        principalTable: "Lessons",
                        principalColumn: "LessonID");
                    table.ForeignKey(
                        name: "FK_ClassRooms_AppUsers_PersonID_FK",
                        column: x => x.PersonID_FK,
                        principalTable: "AppUsers",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "WeeklySchedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<byte>(nullable: false),
                    DayName = table.Column<string>(maxLength: 20, nullable: true),
                    StartCourse = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LessonID_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_WeeklySchedules_Lessons_LessonID_FK",
                        column: x => x.LessonID_FK,
                        principalTable: "Lessons",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateTable(
                name: "ClassRegisters",
                columns: table => new
                {
                    RegisterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoomID_FK = table.Column<int>(nullable: false),
                    ClassRoomClassID = table.Column<int>(nullable: true),
                    PersonID_FK = table.Column<string>(nullable: false),
                    PersonId = table.Column<string>(nullable: true),
                    ClassTypeID_FK = table.Column<int>(nullable: false),
                    ClassTimeTypeID_FK = table.Column<int>(nullable: false),
                    StudentNumber = table.Column<short>(nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRegisters", x => x.RegisterID);
                    table.ForeignKey(
                        name: "FK_ClassRegisters_ClassRooms_ClassRoomClassID",
                        column: x => x.ClassRoomClassID,
                        principalTable: "ClassRooms",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRegisters_ClassTimeTypes_ClassTimeTypeID_FK",
                        column: x => x.ClassTimeTypeID_FK,
                        principalTable: "ClassTimeTypes",
                        principalColumn: "TypeID");
                    table.ForeignKey(
                        name: "FK_ClassRegisters_ClassTypes_ClassTypeID_FK",
                        column: x => x.ClassTypeID_FK,
                        principalTable: "ClassTypes",
                        principalColumn: "ClassTypeID");
                    table.ForeignKey(
                        name: "FK_ClassRegisters_AppUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AppUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ClassTimeTypes",
                columns: new[] { "TypeID", "ClassTimeTypeTitle", "IsActive" },
                values: new object[,]
                {
                    { 1, "کلاس جبرانی", false },
                    { 2, "کلاس عادی", false }
                });

            migrationBuilder.InsertData(
                table: "ClassTypes",
                columns: new[] { "ClassTypeID", "ClassTypeTitle", "IsActive" },
                values: new object[,]
                {
                    { 1, "حضوری", false },
                    { 2, "مجازی", false }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRegisters_ClassRoomClassID",
                table: "ClassRegisters",
                column: "ClassRoomClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRegisters_ClassTimeTypeID_FK",
                table: "ClassRegisters",
                column: "ClassTimeTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRegisters_ClassTypeID_FK",
                table: "ClassRegisters",
                column: "ClassTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRegisters_PersonId",
                table: "ClassRegisters",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_LessonID_FK",
                table: "ClassRooms",
                column: "LessonID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_PersonID_FK",
                table: "ClassRooms",
                column: "PersonID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_LessonID_FK",
                table: "WeeklySchedules",
                column: "LessonID_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClassRegisters");

            migrationBuilder.DropTable(
                name: "WeeklySchedules");

            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "ClassTimeTypes");

            migrationBuilder.DropTable(
                name: "ClassTypes");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
