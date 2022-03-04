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


    }
}
