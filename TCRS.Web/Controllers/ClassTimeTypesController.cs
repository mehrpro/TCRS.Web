using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCRS.Web.Models;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.Controllers
{
    public class ClassTimeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassTimeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassTimeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassTimeTypes.ToListAsync());
        }

        // GET: ClassTimeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTimeType = await _context.ClassTimeTypes
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (classTimeType == null)
            {
                return NotFound();
            }

            return View(classTimeType);
        }

        // GET: ClassTimeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassTimeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeID,ClassTimeTypeTitle,IsActive")] ClassTimeType classTimeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classTimeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classTimeType);
        }

        // GET: ClassTimeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTimeType = await _context.ClassTimeTypes.FindAsync(id);
            if (classTimeType == null)
            {
                return NotFound();
            }
            return View(classTimeType);
        }

        // POST: ClassTimeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeID,ClassTimeTypeTitle,IsActive")] ClassTimeType classTimeType)
        {
            if (id != classTimeType.TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classTimeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassTimeTypeExists(classTimeType.TypeID))
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
            return View(classTimeType);
        }

        // GET: ClassTimeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTimeType = await _context.ClassTimeTypes
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (classTimeType == null)
            {
                return NotFound();
            }

            return View(classTimeType);
        }

        // POST: ClassTimeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classTimeType = await _context.ClassTimeTypes.FindAsync(id);
            _context.ClassTimeTypes.Remove(classTimeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassTimeTypeExists(int id)
        {
            return _context.ClassTimeTypes.Any(e => e.TypeID == id);
        }
    }
}
