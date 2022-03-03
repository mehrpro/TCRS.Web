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
    }
}
