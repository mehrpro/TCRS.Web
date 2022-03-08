using System;

namespace TCRS.Web.ViewModels.AcademicYearViewModel
{
    public class AcademicYearEditViewModel
    {
        public int YearID { get; set; }
        public string YearTitle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}