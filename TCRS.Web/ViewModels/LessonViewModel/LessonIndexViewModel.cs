using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.ViewModels.LessonViewModel
{
    public class LessonIndexViewModel
    {

        public int LessonID { get; set; }
        [Display(Name = "کد")]
        public string LessonCode { get; set; }
        [Display(Name = "عنوان درس")]
        public string LessonTitle { get; set; }
        [Display(Name = "تعداد واحد")]
        public byte NumberOfCourseUnits { get; set; }

        public bool IsActive { get; set; }
    }
}
