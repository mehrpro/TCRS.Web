using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.ViewModels.ClassTypeViewModel
{
    public class ClassTypeCreateViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} باید وارد شود")]
        [MaxLength(100)]
        [Remote("IsUsedClassTypeTitle", "ClassTypes", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string ClassTypeTitle { get; set; }
    }
}
