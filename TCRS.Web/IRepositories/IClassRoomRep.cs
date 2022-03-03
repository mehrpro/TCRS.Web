using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models.Entities;
using TCRS.Web.Models;

namespace TCRS.Web.IRepositories
{
    public interface IClassRoomRep : IRepository<ClassRoom>
    {
    }

    public class ClassRoomRep : Repository<ClassRoom>, IClassRoomRep
    {
        public ClassRoomRep(ApplicationDbContext context) : base(context)
        {

        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
