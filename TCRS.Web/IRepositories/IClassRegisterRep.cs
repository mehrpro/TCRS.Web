using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface IClassRegisterRep : IRepository<ClassRegister>
    {
        void UpdateClassRegister(ClassRegister model);
    }

    public class ClassRegisterRep : Repository<ClassRegister>, IClassRegisterRep
    {
        public ClassRegisterRep(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void UpdateClassRegister(ClassRegister model)
        {
            var local = ApplicationDbContext.ClassRegisters.Local.FirstOrDefault(entry => entry.RegisterID.Equals(model.RegisterID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
