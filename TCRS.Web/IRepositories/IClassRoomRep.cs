using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCRS.Web.Models.Entities;
using TCRS.Web.Models;

namespace TCRS.Web.IRepositories
{
    public interface IClassRoomRep : IRepository<ClassRoom>
    {
        Task UpdateClassRoom(ClassRoom model);

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

        public async Task UpdateClassRoom(ClassRoom model)
        {
            var local = ApplicationDbContext.ClassRooms.Local.FirstOrDefault(entry => entry.ClassID.Equals(model.ClassID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
