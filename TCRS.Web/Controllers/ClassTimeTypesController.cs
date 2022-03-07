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
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;
using TCRS.Web.ViewModels.ClassTimeTypeViewModel;

namespace TCRS.Web.Controllers
{
    public class ClassTimeTypesController : Controller
    {
        private readonly IClassTimeTypeService _classTimeTypeService;
        private readonly IMapper _mapper;

        public ClassTimeTypesController(IClassTimeTypeService classTimeTypeService, IMapper mapper)
        {
            _classTimeTypeService = classTimeTypeService;
            _mapper = mapper;
        }

        // GET: ClassTimeTypes
        public async Task<IActionResult> Index()
        {
            var result = await _classTimeTypeService.GetAll();
            var resultMap = _mapper.Map<IList<ClassTimeTypeIndexViewModel>>(result);
            return View(resultMap);
        }


        // GET: ClassTimeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassTimeTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassTimeTypeTitle")] ClassTimeTypeCreateViewModel classTimeType)
        {
            if (ModelState.IsValid)
            {
                var resultMap = _mapper.Map<ClassTimeType>(classTimeType);
                resultMap.IsActive = true;
                var result = await _classTimeTypeService.Create(resultMap);
                if (result) return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", PublicValues.ErrorSave);
            }
            return View(classTimeType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUsedClassTimeTypeTitle(string ClassTimeTypeTitle)
        {
            var result = await _classTimeTypeService.GetByName(ClassTimeTypeTitle);
            return (result == false) ? Json(true) : Json("این عنوان قبلا در سایت ثبت شده است");
        }

        // GET: ClassTimeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var resultFind = await _classTimeTypeService.GetById((int)id);
            var resultMap = _mapper.Map<ClassTimeTypeEditViewModel>(resultFind);
            if (resultMap == null)
            {
                return NotFound();
            }
            return View(resultMap);
        }


        // POST: ClassTimeTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeID,ClassTimeTypeTitle,IsActive")] ClassTimeTypeEditViewModel classTimeType)
        {
            if (id != classTimeType.TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var resultIf = await _classTimeTypeService.GetByCondition(x => x.ClassTimeTypeTitle == classTimeType.ClassTimeTypeTitle);
                if (resultIf == null || resultIf.TypeID == classTimeType.TypeID)
                {
                    var resultMap = _mapper.Map<ClassTimeType>(classTimeType);
                    var resultUpdate = await _classTimeTypeService.Update(resultMap);
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
            return View(classTimeType);
        }

    }
}
