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
    public class ClassTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassTypes.ToListAsync());
        }

        // GET: ClassTypes/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: ClassTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassTypeID,ClassTypeTitle,IsActive")] ClassType classType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classType);
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
