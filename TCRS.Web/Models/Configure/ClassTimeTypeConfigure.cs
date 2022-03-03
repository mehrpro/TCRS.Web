using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;


namespace TCRS.Web.Models.Configure
{
    public class ClassTimeTypeConfigure : IEntityTypeConfiguration<ClassTimeType>
    {
        public void Configure(EntityTypeBuilder<ClassTimeType> builder)
        {
            builder.HasKey(x => x.TypeID);
            builder.Property(x => x.TypeID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ClassTimeTypeTitle).HasMaxLength(100).IsRequired();
            builder.HasMany(x => x.ClassRegisters)
                .WithOne(x => x.ClassTimeType)
                .HasForeignKey(x => x.ClassTimeTypeID_FK)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(
                new ClassTimeType { TypeID = 1, ClassTimeTypeTitle = @"کلاس جبرانی" },
                new ClassTimeType { TypeID = 2, ClassTimeTypeTitle = @"کلاس عادی" }
            );
        }
    }
}
