using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Models.Entities
{
    public class WeeklySchedule
    {
        /// <summary>
        /// برنامه هفتگی
        /// </summary>
        public int ScheduleID { get; set; }
        public byte DayOfWeek { get; set; }
        public string DayName { get; set; }
        public DateTime StartCourse { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }



        public int LessonID_FK { get; set; }
        public Lesson Lesson { get; set; }




    }
}
