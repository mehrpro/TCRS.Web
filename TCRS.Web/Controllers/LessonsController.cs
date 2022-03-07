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
using TCRS.Web.ViewModels.LessonViewModel;

namespace TCRS.Web.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonsController(ILessonService lessonService, IMapper mapper)
        {
            _mapper = mapper;
            _lessonService = lessonService;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var resultAll = await _lessonService.GetAll();
            var resultMap = _mapper.Map<IEnumerable<LessonIndexViewModel>>(resultAll);
            return View(resultMap);
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var lesson = await _lessonService.GetById((int)id);
            if (lesson == null)
                return NotFound();
            var resultMap = _mapper.Map<LessonEditViewModel>(lesson);

            return View(resultMap);
        }

        // GET: Lessons/Create
        public IActionResult Create() => View();

        // POST: Lessons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonTitle,NumberOfCourseUnits,LessonCode,PresentationCode")] LessonCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resultMap = _mapper.Map<Lesson>(model);
                var resultCreate = await _lessonService.Create(resultMap);
                if (resultCreate)
                    return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", PublicValues.ErrorSave);
            return View(model);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var lesson = await _lessonService.GetById((int)id);
            if (lesson == null)
                return NotFound();
            var resultMap = _mapper.Map<LessonEditViewModel>(lesson);
            return View(resultMap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUsedLessonCode(string lessonCode)
        {
            var result = await _lessonService.AnyByCondition(x => x.LessonCode == lessonCode);
            return result ? Json("این کد درس قبلا در سایت ثبت  شده است") : Json(true);
        }


        // POST: Lessons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonID,LessonTitle,NumberOfCourseUnits,LessonCode,PresentationCode,IsActive")] LessonEditViewModel model)
        {
            if (id != model.LessonID)
                return NotFound();
            var lesson = await _lessonService.GetById((int)id);
            if (lesson == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                var resultMap = _mapper.Map<Lesson>(model);
                var resultUpdate = await _lessonService.Update(resultMap);
                if (resultUpdate)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", PublicValues.ErrorSave);
            }
            else
                ModelState.AddModelError("", PublicValues.ErrorSave);
            return View(model);
        }




        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _lessonService.GetById((int)id);
            if (lesson == null)
                return NotFound();
            var result = await _lessonService.DisableEnable(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
