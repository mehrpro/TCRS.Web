using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TCRS.Web.Models.Configure;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<Person, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ClassRegisterConfigure());
            builder.ApplyConfiguration(new ClassRoomConfigure());
            builder.ApplyConfiguration(new ClassTimeTypeConfigure());
            builder.ApplyConfiguration(new ClassTypeConfigure());
            builder.ApplyConfiguration(new LessonConfigure());
            builder.ApplyConfiguration(new PersonConfigure());
            builder.ApplyConfiguration(new WeeklyScheduleConfigure());
            builder.ApplyConfiguration(new AppRoleConfigure());

        }

        public virtual DbSet<ClassRegister> ClassRegisters { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<ClassTimeType> ClassTimeTypes { get; set; }
        public virtual DbSet<ClassType> ClassTypes { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<WeeklySchedule> WeeklySchedules { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }


    }
}
