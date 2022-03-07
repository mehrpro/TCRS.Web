using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCRS.Web.ExtentionService;
using TCRS.Web.IServices;
using TCRS.Web.Models.Entities;
using TCRS.Web.ViewModels.ClassTypeViewModel;

namespace TCRS.Web.Controllers
{
    public class ClassTypesController : Controller
    {
        private readonly IClassTypeService _classTypeService;
        private readonly IMapper _mapper;

        public ClassTypesController(IClassTypeService classTypeService, IMapper mapper)
        {
            _classTypeService = classTypeService;
            _mapper = mapper;
        }

        // GET: ClassTypes
        public async Task<IActionResult> Index()
        {
            var resultFind = await _classTypeService.GetAll();
            var resultMap = _mapper.Map<IList<ClassTypeIndexViewModel>>(resultFind);
            return View(resultMap);
        }



        // GET: ClassTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassTypeTitle")] ClassTypeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resultMap = _mapper.Map<ClassType>(model);
                resultMap.IsActive = true;
                var result = await _classTypeService.Create(resultMap);
                if (result) return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", PublicValues.ErrorSave);
            }
            return View(model);
        }

        // GET: ClassTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resultFind = await _classTypeService.GetById((int)id);
            var resultMap = _mapper.Map<ClassTypeEditViewModel>(resultFind);
            if (resultMap == null)
            {
                return NotFound();
            }
            return View(resultMap);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUsedClassTypeTitle(string ClassTypeTitle)
        {
            var result = await _classTypeService.GetByName(ClassTypeTitle);
            return (result == false) ? Json(true) : Json("این عنوان قبلا در سایت ثبت شده است");
        }

        // POST: ClassTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassTypeID,ClassTypeTitle,IsActive")] ClassTypeEditViewModel classType)
        {
            if (id != classType.ClassTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var resultIf = await _classTypeService.GetByCondition(x => x.ClassTypeTitle == classType.ClassTypeTitle);
                if (resultIf == null || resultIf.ClassTypeID == classType.ClassTypeID)
                {
                    var resultMap = _mapper.Map<ClassType>(classType);
                    var resultUpdate = await _classTypeService.Update(resultMap);
                    if (resultUpdate)
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", PublicValues.ErrorSave);
                }
                else
                    ModelState.AddModelError("", "این عنوان تکراری است!");
            }
            else
                ModelState.AddModelError("", PublicValues.ErrorSave);
            return View(classType);
        }

    }
}
