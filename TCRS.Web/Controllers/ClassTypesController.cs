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

            var classType = await _context.ClassTypes.FindAsync(id);
            if (classType == null)
            {
                return NotFound();
            }
            return View(classType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUsedClassTypeTitle(string ClassTypeTitle)
        {
            var result = await _classTypeService.GetByName(ClassTypeTitle);
            return (result == false) ? Json(true) : Json("این ایمیل قبلا در سایت ثبت نام شده است");
        }

        // POST: ClassTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassTypeID,ClassTypeTitle,IsActive")] ClassType classType)
        {
            if (id != classType.ClassTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassTypeExists(classType.ClassTypeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classType);
        }

        // GET: ClassTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classType = await _context.ClassTypes
                .FirstOrDefaultAsync(m => m.ClassTypeID == id);
            if (classType == null)
            {
                return NotFound();
            }

            return View(classType);
        }

        // POST: ClassTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classType = await _context.ClassTypes.FindAsync(id);
            _context.ClassTypes.Remove(classType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassTypeExists(int id)
        {
            return _context.ClassTypes.Any(e => e.ClassTypeID == id);
        }
    }
}
