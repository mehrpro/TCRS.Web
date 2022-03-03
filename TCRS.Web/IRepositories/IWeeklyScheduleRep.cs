using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IRepositories
{
    public interface IWeeklyScheduleRep : IRepository<WeeklySchedule>
    {
    }
    public class WeeklyScheduleRep : Repository<WeeklySchedule>, IWeeklyScheduleRep
    {
        public WeeklyScheduleRep(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
