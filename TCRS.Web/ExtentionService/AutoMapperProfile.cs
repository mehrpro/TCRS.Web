using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models.Entities;
using TCRS.Web.ViewModels.ClassTypeViewModel;

namespace TCRS.Web.ExtentionService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClassTypeIndexViewModel, ClassType>().ReverseMap();
        }
    }
}
