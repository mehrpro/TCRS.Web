using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class ClassRoomConfigure : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {

            builder.HasKey(x => x.ClassID);
            builder.Property(x => x.ClassID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.PersonID_FK).IsRequired();
            builder.Property(x => x.LessonID_FK).IsRequired();
            builder.Property(x => x.SemesterID_FK).IsRequired();
            builder.Property(x => x.RegisterDate).HasColumnType("datetime");


        }
    }
}