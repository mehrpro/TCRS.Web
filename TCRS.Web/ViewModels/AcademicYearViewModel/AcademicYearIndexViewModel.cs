using System.ComponentModel.DataAnnotations;

namespace TCRS.Web.ViewModels.AcademicYearViewModel
{
    public class AcademicYearIndexViewModel
    {

        public int YearID { get; set; }
        [Display(Name = "سال تحصیلی")]
        public string YearTitle { get; set; }

        public bool IsActive { get; set; }
    }
}