using System.Linq;
using Microsoft.EntityFrameworkCore;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface ISemesterRep : IRepository<Semester>
    {
        void UpdateSemester(Semester model);
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

        public void UpdateSemester(Semester model)
        {
            var local = ApplicationDbContext.Semesters.Local.FirstOrDefault(entry => entry.SemesterID.Equals(model.SemesterID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }
    }
}