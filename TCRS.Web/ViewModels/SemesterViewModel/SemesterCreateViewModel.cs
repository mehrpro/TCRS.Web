using System;
using System.ComponentModel.DataAnnotations;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.ViewModels.SemesterViewModel
{
    public class SemesterCreateViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [MaxLength(64)]
        public string SemesterTitle { get; set; }
        public int AcademicYearID_FK { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}