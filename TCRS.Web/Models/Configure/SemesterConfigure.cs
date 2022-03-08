using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class SemesterConfigure : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.HasKey(x => x.SemesterID);
            builder.Property(x => x.SemesterID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.SemesterTitle).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.ClassRooms)
                .WithOne(x => x.Semester)
                .HasForeignKey(x => x.SemesterID_FK)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(new Semester()
            {
                SemesterID = 1,
                SemesterTitle = "نیم سال اول",
                AcademicYearID_FK = 1,
                IsActive = true,

            },
                new Semester
                {
                    SemesterID = 2,
                    SemesterTitle = "نیم سال دوم",
                    AcademicYearID_FK = 1,
                    IsActive = true
                });
        }
    }
}