using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface ISemesterRep : IRepository<Semester>
    {

    }

    public class SemesterRep : Repository<Semester>, ISemesterRep
    {
        public SemesterRep(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}