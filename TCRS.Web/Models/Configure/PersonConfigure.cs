using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class PersonConfigure : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.Id).HasColumnName("UserID");
            builder.ToTable("AppUsers");
            builder.Property(x => x.FName).HasMaxLength(100);
            builder.Property(x => x.LName).HasMaxLength(100);
            builder.Property(x => x.NationalCode).HasMaxLength(11);
            builder.HasMany(x => x.ClassRooms)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonID_FK)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
