using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class AcademicYearConfigure : IEntityTypeConfiguration<AcademicYear>
    {
        public void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            builder.HasKey(x => x.YearID);
            builder.Property(x => x.YearID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.YearTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.StartTime).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.EndTime).IsRequired().HasColumnType("datetime");
            builder.HasMany(x => x.Semesters)
                .WithOne(x => x.AcademicYear)
                .HasForeignKey(x => x.AcademicYearID_FK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new AcademicYear
            {
                YearID = 1,
                YearTitle = "1400-1401",
                StartTime = new DateTime(2021, 09, 23),
                EndTime = new DateTime(2022, 06, 21),
                IsActive = true,

            });
        }
    }
}