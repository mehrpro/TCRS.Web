using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class LessonConfigure : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.LessonID);
            builder.Property(x => x.LessonID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.LessonTitle).IsRequired().HasMaxLength(150);
            builder.Property(x => x.LessonCode).HasMaxLength(50);
            builder.Property(x => x.PresentationCode).HasMaxLength(50);
            builder.Property(x => x.NumberOfCourseUnits).IsRequired();
            builder.HasMany(x => x.ClassRooms)
                .WithOne(x => x.Lesson)
                .HasForeignKey(x => x.LessonID_FK)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.WeeklySchedules)
                .WithOne(x => x.Lesson)
                .HasForeignKey(x => x.LessonID_FK)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}