﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCRS.Web.Models;

namespace TCRS.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220308184324_AddAcademicYear")]
    partial class AddAcademicYear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.AcademicYear", b =>
                {
                    b.Property<int>("YearID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("YearTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("YearID");

                    b.ToTable("AcademicYears");

                    b.HasData(
                        new
                        {
                            YearID = 1,
                            EndTime = new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            StartTime = new DateTime(2021, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearTitle = "1400-1401"
                        });
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AppRole");
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.ClassRegister", b =>
                {
                    b.Property<int>("RegisterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassRoomClassID")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomID_FK")
                        .HasColumnType("int");

                    b.Property<int>("ClassTimeTypeID_FK")
                        .HasColumnType("int");

                    b.Property<int>("ClassTypeID_FK")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PersonID_FK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<short>("StudentNumber")
                        .HasColumnType("smallint");

                    b.HasKey("RegisterID");

                    b.HasIndex("ClassRoomClassID");

                    b.HasIndex("ClassTimeTypeID_FK");

                    b.HasIndex("ClassTypeID_FK");

                    b.HasIndex("PersonId");

                    b.ToTable("ClassRegisters");
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.ClassRoom", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LessonID_FK")
                        .HasColumnType("int");

                    b.Property<string>("PersonID_FK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SemesterID_FK")
                        .HasColumnType("int");

                    b.Property<short>("StudentNumber")
                        .HasColumnType("smallint");

                    b.HasKey("ClassID");

                    b.HasIndex("LessonID_FK");

                    b.HasIndex("PersonID_FK");

                    b.HasIndex("SemesterID_FK");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.ClassTimeType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassTimeTypeTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("TypeID");

                    b.ToTable("ClassTimeTypes");

                    b.HasData(
                        new
                        {
                            TypeID = 1,
                            ClassTimeTypeTitle = "کلاس جبرانی",
                            IsActive = false
                        },
                        new
                        {
                            TypeID = 2,
                            ClassTimeTypeTitle = "کلاس عادی",
                            IsActive = false
                        });
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.ClassType", b =>
                {
                    b.Property<int>("ClassTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassTypeTitle")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ClassTypeID");

                    b.ToTable("ClassTypes");

                    b.HasData(
                        new
                        {
                            ClassTypeID = 1,
                            ClassTypeTitle = "حضوری",
                            IsActive = false
                        },
                        new
                        {
                            ClassTypeID = 2,
                            ClassTypeTitle = "مجازی",
                            IsActive = false
                        });
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LessonCode")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LessonTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<byte>("NumberOfCourseUnits")
                        .HasColumnType("tinyint");

                    b.Property<string>("PresentationCode")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("LessonID");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            LessonID = 1,
                            IsActive = true,
                            LessonCode = "112233",
                            LessonTitle = "مبانی برنامه نویسی وب",
                            NumberOfCourseUnits = (byte)2,
                            PresentationCode = "332211"
                        },
                        new
                        {
                            LessonID = 2,
                            IsActive = true,
                            LessonCode = "225563",
                            LessonTitle = "معارف اسلامی",
                            NumberOfCourseUnits = (byte)2,
                            PresentationCode = "958574"
                        });
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.Semester", b =>
                {
                    b.Property<int>("SemesterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicYearID_FK")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SemesterTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("SemesterID");

                    b.HasIndex("AcademicYearID_FK");

                    b.ToTable("Semesters");

                    b.HasData(
                        new
                        {
                            SemesterID = 1,
                            AcademicYearID_FK = 1,
                            EndTime = new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            SemesterTitle = "نیم سال اول",
                            StartTime = new DateTime(2021, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SemesterID = 2,
                            AcademicYearID_FK = 1,
                            EndTime = new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            SemesterTitle = "نیم سال دوم",
                            StartTime = new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.WeeklySchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte>("DayOfWeek")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LessonID_FK")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartCourse")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("ScheduleID");

                    b.HasIndex("LessonID_FK");

                    b.ToTable("WeeklySchedules");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCRS.Web.Models.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.ClassRegister", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomClassID");

                    b.HasOne("TCRS.Web.Models.Entities.ClassTimeType", "ClassTimeType")
                        .WithMany("ClassRegisters")
                        .HasForeignKey("ClassTimeTypeID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCRS.Web.Models.Entities.ClassType", "ClassType")
                        .WithMany("ClassRegisters")
                        .HasForeignKey("ClassTypeID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCRS.Web.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.ClassRoom", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.Lesson", "Lesson")
                        .WithMany("ClassRooms")
                        .HasForeignKey("LessonID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCRS.Web.Models.Entities.Person", "Person")
                        .WithMany("ClassRooms")
                        .HasForeignKey("PersonID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TCRS.Web.Models.Entities.Semester", "Semester")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SemesterID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.Semester", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.AcademicYear", "AcademicYear")
                        .WithMany("Semesters")
                        .HasForeignKey("AcademicYearID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TCRS.Web.Models.Entities.WeeklySchedule", b =>
                {
                    b.HasOne("TCRS.Web.Models.Entities.Lesson", "Lesson")
                        .WithMany("WeeklySchedules")
                        .HasForeignKey("LessonID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
