using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TCRS.Web.ViewModels.ClassTypeViewModel
{
    public class ClassTypeEditViewModel
    {
        [Display(Name = "شناسه")]
        public int ClassTypeID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [MaxLength(100)]
        public string ClassTypeTitle { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
    }
}
