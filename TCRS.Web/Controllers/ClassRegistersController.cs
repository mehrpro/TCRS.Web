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
    public class ClassRegistersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassRegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassRegisters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClassRegisters.Include(c => c.ClassTimeType).Include(c => c.ClassType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClassRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRegister = await _context.ClassRegisters
                .Include(c => c.ClassTimeType)
                .Include(c => c.ClassType)
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (classRegister == null)
            {
                return NotFound();
            }

            return View(classRegister);
        }

        // GET: ClassRegisters/Create
        public IActionResult Create()
        {
            ViewData["ClassTimeTypeID_FK"] = new SelectList(_context.ClassTimeTypes, "TypeID", "ClassTimeTypeTitle");
            ViewData["ClassTypeID_FK"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeID");
            return View();
        }

        // POST: ClassRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterID,ClassRoomID_FK,PersonID_FK,ClassTypeID_FK,ClassTimeTypeID_FK,StudentNumber,StartTime,EndTime,IsActive")] ClassRegister classRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassTimeTypeID_FK"] = new SelectList(_context.ClassTimeTypes, "TypeID", "ClassTimeTypeTitle", classRegister.ClassTimeTypeID_FK);
            ViewData["ClassTypeID_FK"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeID", classRegister.ClassTypeID_FK);
            return View(classRegister);
        }

        // GET: ClassRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRegister = await _context.ClassRegisters.FindAsync(id);
            if (classRegister == null)
            {
                return NotFound();
            }
            ViewData["ClassTimeTypeID_FK"] = new SelectList(_context.ClassTimeTypes, "TypeID", "ClassTimeTypeTitle", classRegister.ClassTimeTypeID_FK);
            ViewData["ClassTypeID_FK"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeID", classRegister.ClassTypeID_FK);
            return View(classRegister);
        }

        // POST: ClassRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegisterID,ClassRoomID_FK,PersonID_FK,ClassTypeID_FK,ClassTimeTypeID_FK,StudentNumber,StartTime,EndTime,IsActive")] ClassRegister classRegister)
        {
            if (id != classRegister.RegisterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRegisterExists(classRegister.RegisterID))
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
            ViewData["ClassTimeTypeID_FK"] = new SelectList(_context.ClassTimeTypes, "TypeID", "ClassTimeTypeTitle", classRegister.ClassTimeTypeID_FK);
            ViewData["ClassTypeID_FK"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeID", classRegister.ClassTypeID_FK);
            return View(classRegister);
        }

        // GET: ClassRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRegister = await _context.ClassRegisters
                .Include(c => c.ClassTimeType)
                .Include(c => c.ClassType)
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (classRegister == null)
            {
                return NotFound();
            }

            return View(classRegister);
        }

        // POST: ClassRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classRegister = await _context.ClassRegisters.FindAsync(id);
            _context.ClassRegisters.Remove(classRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRegisterExists(int id)
        {
            return _context.ClassRegisters.Any(e => e.RegisterID == id);
        }
    }
}
