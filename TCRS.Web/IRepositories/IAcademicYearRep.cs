using System.Linq;
using Microsoft.EntityFrameworkCore;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface IAcademicYearRep : IRepository<AcademicYear>
    {
        void UpdateAcademicYear(AcademicYear model);
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

        public void UpdateAcademicYear(AcademicYear model)
        {
            var local = ApplicationDbContext.AcademicYears.Local.FirstOrDefault(entry => entry.YearID.Equals(model.YearID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }
    }
}