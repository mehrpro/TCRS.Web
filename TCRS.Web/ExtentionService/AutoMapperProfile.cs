using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRS.Web.Models.Entities;
using TCRS.Web.ViewModels.AcademicYearViewModel;
using TCRS.Web.ViewModels.ClassTimeTypeViewModel;
using TCRS.Web.ViewModels.ClassTypeViewModel;
using TCRS.Web.ViewModels.LessonViewModel;

namespace TCRS.Web.ExtentionService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClassTypeIndexViewModel, ClassType>().ReverseMap();
            CreateMap<ClassTypeCreateViewModel, ClassType>().ReverseMap();
            CreateMap<ClassTypeEditViewModel, ClassType>().ReverseMap();
            CreateMap<ClassTimeType, ClassTimeTypeIndexViewModel>().ReverseMap();
            CreateMap<ClassTimeType, ClassTimeTypeCreateViewModel>().ReverseMap();
            CreateMap<ClassTimeType, ClassTimeTypeEditViewModel>().ReverseMap();
            CreateMap<Lesson, LessonCreateViewModel>().ReverseMap();
            CreateMap<Lesson, LessonIndexViewModel>().ReverseMap();
            CreateMap<Lesson, LessonEditViewModel>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearIndexViewModel>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearCreateViewModel>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearEditViewModel>().ReverseMap();



        }
    }
}
