using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;
using TCRS.Web.ViewModels.ClassTypeViewModel;

namespace TCRS.Web.IRepositories
{
    public interface IClassTypeRep : IRepository<ClassType>
    {
        void UpdateClassType(ClassType model);
    }

    public class ClassTypeRep : Repository<ClassType>, IClassTypeRep
    {
        public ClassTypeRep(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }


        public void UpdateClassType(ClassType model)
        {
            var local = ApplicationDbContext.ClassTypes.Local.FirstOrDefault(entry => entry.ClassTypeID.Equals(model.ClassTypeID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }

    }
}
