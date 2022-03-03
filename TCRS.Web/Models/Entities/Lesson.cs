using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Models.Entities
{
    public class Lesson
    {
        /// <summary>
        /// عنوان درس
        /// </summary>
        public Lesson()
        {
            ClassRooms = new HashSet<ClassRoom>();
            WeeklySchedules = new HashSet<WeeklySchedule>();
        }

        public int LessonID { get; set; }
        public string LessonTitle { get; set; }
        public byte NumberOfCourseUnits { get; set; }
        public string LessonCode { get; set; }
        public string PresentationCode { get; set; }


        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<WeeklySchedule> WeeklySchedules { get; set; }

    }
}
