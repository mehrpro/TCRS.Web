using System.Collections.Generic;

namespace TCRS.Web.Models.Entities
{
    public class Semester
    {
        public Semester()
        {
            ClassRooms = new HashSet<ClassRoom>();
        }
        public int SemesterID { get; set; }
        public string SemesterTitle { get; set; }
        public int AcademicYearID_FK { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }

    }
}