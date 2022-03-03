using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class WeeklyScheduleConfigure : IEntityTypeConfiguration<WeeklySchedule>
    {
        public void Configure(EntityTypeBuilder<WeeklySchedule> builder)
        {
            builder.HasKey(x => x.ScheduleID);
            builder.Property(x => x.ScheduleID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.DayName).HasMaxLength(20);
            builder.Property(x => x.DayName).HasMaxLength(20);
            builder.Property(x => x.StartCourse).HasColumnType("datetime");
            builder.Property(x => x.StartTime).HasColumnType("datetime");
            builder.Property(x => x.EndTime).HasColumnType("datetime");
            builder.Property(x => x.LessonID_FK).IsRequired();
            builder.Property(x => x.DayOfWeek).IsRequired();
        }
    }
}