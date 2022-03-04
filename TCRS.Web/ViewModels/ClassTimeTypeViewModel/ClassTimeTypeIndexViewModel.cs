using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.ViewModels.ClassTimeTypeViewModel
{
    public class ClassTimeTypeIndexViewModel
    {
        [Display(Name = "شناسه")]
        public int TypeID { get; set; }
        [Display(Name = "عنوان")]
        public string ClassTimeTypeTitle { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
    }
}
