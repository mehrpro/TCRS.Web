using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.ViewModels.ClassTimeTypeViewModel
{
    public class ClassTimeTypeCreateViewModel
    {
        [Remote("IsUsedClassTimeTypeTitle", "ClassTimeTypes", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [MaxLength(100)]
        public string ClassTimeTypeTitle { get; set; }

    }
}
