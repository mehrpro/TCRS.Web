using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.ViewModels.LessonViewModel
{
    public class LessonCreateViewModel
    {
        [Display(Name = "کد درس")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [Remote("IsUsedLessonCode", "Lessons", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]

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

    }
}
