using System.ComponentModel.DataAnnotations;

namespace TCRS.Web.ViewModels.ClassRoomViewModel
{
    public class ClassRoomIndexViewModel
    {

        public int ClassID { get; set; }
        [Display(Name = "کد درس")]
        public string LessonCode { get; set; }

        [Display(Name = "عنوان")]
        public string LessonTitle { get; set; }

        [Display(Name = "تعداد مدرس")]
        public int ProfessorCount { get; set; }

        public bool IsActive { get; set; }


    }
}
