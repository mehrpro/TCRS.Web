using System;
using System.Collections.Generic;

namespace TCRS.Web.Models.Entities
{
    public class AcademicYear
    {
        public AcademicYear()
        {
            Semesters = new HashSet<Semester>();
        }

        /// <summary>
        /// سال تحصیلی
        /// </summary>
        public int YearID { get; set; }
        public string YearTitle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }

    }
}
