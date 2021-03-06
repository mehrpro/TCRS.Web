using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Controllers
{
    public class SemestersController : Controller
    {
        // GET: SemestersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SemestersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SemestersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SemestersController/Create
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

        // GET: SemestersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SemestersController/Edit/5
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

        // GET: SemestersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SemestersController/Delete/5
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
