using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TCRS.Web.ViewModels.LessonViewModel
{
    public class LessonEditViewModel
    {
        [Display(AutoGenerateField = false)]
        public int LessonID { get; set; }

        [Display(Name = "کد درس")]
        public string LessonCode { get; set; }

        [Display(Name = "عنوان درس")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [MaxLength(150)]
        public string LessonTitle { get; set; }

        [Display(Name = "تعداد واحد")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        public byte NumberOfCourseUnits { get; set; }

        [Display(Name = "کد ارائه")]
        public string PresentationCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
    }
}