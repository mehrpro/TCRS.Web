using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Models.Configure
{
    public class ClassRegisterConfigure : IEntityTypeConfiguration<ClassRegister>
    {
        public void Configure(EntityTypeBuilder<ClassRegister> builder)
        {
            builder.HasKey(x => x.RegisterID);
            builder.Property(x => x.RegisterID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.StartTime).HasColumnType("datetime");
            builder.Property(x => x.EndTime).HasColumnType("datetime");
            builder.Property(x => x.ClassRoomID_FK).IsRequired();
            builder.Property(x => x.ClassTypeID_FK).IsRequired();
            builder.Property(x => x.PersonID_FK).IsRequired();

        }
    }
}
