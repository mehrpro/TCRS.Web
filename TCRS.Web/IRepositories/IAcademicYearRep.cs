using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface IAcademicYearRep : IRepository<AcademicYear>
    {

    }

    public class AcademicYearRep : Repository<AcademicYear>, IAcademicYearRep
    {
        public AcademicYearRep(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}