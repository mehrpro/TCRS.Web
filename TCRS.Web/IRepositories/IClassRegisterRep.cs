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
    }
}
