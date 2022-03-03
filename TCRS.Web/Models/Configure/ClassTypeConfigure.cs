using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class ClassTypeConfigure : IEntityTypeConfiguration<ClassType>
    {
        public void Configure(EntityTypeBuilder<ClassType> builder)
        {
            builder.HasKey(x => x.ClassTypeID);
            builder.Property(x => x.ClassTypeID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ClassTypeTitle).HasMaxLength(100);
            builder.HasMany(x => x.ClassRegisters)
                .WithOne(x => x.ClassType)
                .HasForeignKey(x => x.ClassTypeID_FK)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new ClassType() { ClassTypeID = 1, ClassTypeTitle = @"حضوری" },
                new ClassType() { ClassTypeID = 1, ClassTypeTitle = @"مجازی" }
            );
        }
    }
}