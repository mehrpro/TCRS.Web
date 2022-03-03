using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.ViewModels.ClassTypeViewModel
{
    public class ClassTypeIndexViewModel
    {
        [Display(Name = "شناسه")]
        public int ClassTypeID { get; set; }
        [Display(Name = "عنوان")]
        public string ClassTypeTitle { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
    }
}
