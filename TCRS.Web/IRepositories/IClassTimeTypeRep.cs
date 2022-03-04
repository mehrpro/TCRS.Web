using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface IClassTimeTypeRep : IRepository<ClassTimeType>
    {
        void UpdateClassType(ClassTimeType model);
    }

    public class ClassTimeTypeRep : Repository<ClassTimeType>, IClassTimeTypeRep
    {
        public ClassTimeTypeRep(ApplicationDbContext context) : base(context)
        {

        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void UpdateClassType(ClassTimeType model)
        {
            var local = ApplicationDbContext.ClassTimeTypes.Local.FirstOrDefault(entry => entry.TypeID.Equals(model.TypeID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
