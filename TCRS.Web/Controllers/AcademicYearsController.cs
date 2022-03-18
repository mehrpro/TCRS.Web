using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TCRS.Web.IServices;
using TCRS.Web.ViewModels.AcademicYearViewModel;

namespace TCRS.Web.Controllers
{
    public class AcademicYearsController : Controller
    {
        private readonly IAcademicYearService _academicYearService;
        private readonly IMapper _mapper;

        public AcademicYearsController(IAcademicYearService academicYearService, IMapper mapper)
        {
            _academicYearService = academicYearService;
            _mapper = mapper;
        }


        // GET: AcademicYearsController
        public async Task<ActionResult> Index()
        {
            var result = await _academicYearService.GetAll();
            var resultMap = _mapper.Map<IEnumerable<AcademicYearIndexViewModel>>(result);
            return View(resultMap);
        }

        // GET: AcademicYearsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AcademicYearsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYearsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AcademicYearsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AcademicYearsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AcademicYearsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AcademicYearsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
