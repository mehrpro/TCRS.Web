using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Models.Entities
{
    public class ClassRoom
    {
        /// <summary>
        /// کلاس 
        /// </summary>
        public int ClassID { get; set; }
        public string PersonID_FK { get; set; }
        public Person Person { get; set; }
        public int LessonID_FK { get; set; }
        public Lesson Lesson { get; set; }
        public short StudentNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
