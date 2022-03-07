using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface ILessonRep : IRepository<Lesson>
    {
        void UpdateLesson(Lesson model);
    }
    public class LessonRep : Repository<Lesson>, ILessonRep
    {
        public LessonRep(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }


        public void UpdateLesson(Lesson model)
        {
            var local = ApplicationDbContext.Lessons.Local.FirstOrDefault(entry => entry.LessonID.Equals(model.LessonID));
            if (local != null)
            {
                ApplicationDbContext.Entry(local).State = EntityState.Detached;
            }
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
