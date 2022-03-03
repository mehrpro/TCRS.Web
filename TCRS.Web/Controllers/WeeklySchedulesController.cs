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
    public class WeeklySchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeeklySchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeeklySchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WeeklySchedules.Include(w => w.Lesson);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WeeklySchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklySchedule = await _context.WeeklySchedules
                .Include(w => w.Lesson)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (weeklySchedule == null)
            {
                return NotFound();
            }

            return View(weeklySchedule);
        }

        // GET: WeeklySchedules/Create
        public IActionResult Create()
        {
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle");
            return View();
        }

        // POST: WeeklySchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleID,DayOfWeek,DayName,StartCourse,StartTime,EndTime,IsActive,LessonID_FK")] WeeklySchedule weeklySchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weeklySchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle", weeklySchedule.LessonID_FK);
            return View(weeklySchedule);
        }

        // GET: WeeklySchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklySchedule = await _context.WeeklySchedules.FindAsync(id);
            if (weeklySchedule == null)
            {
                return NotFound();
            }
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle", weeklySchedule.LessonID_FK);
            return View(weeklySchedule);
        }

        // POST: WeeklySchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleID,DayOfWeek,DayName,StartCourse,StartTime,EndTime,IsActive,LessonID_FK")] WeeklySchedule weeklySchedule)
        {
            if (id != weeklySchedule.ScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weeklySchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeeklyScheduleExists(weeklySchedule.ScheduleID))
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
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle", weeklySchedule.LessonID_FK);
            return View(weeklySchedule);
        }

        // GET: WeeklySchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weeklySchedule = await _context.WeeklySchedules
                .Include(w => w.Lesson)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (weeklySchedule == null)
            {
                return NotFound();
            }

            return View(weeklySchedule);
        }

        // POST: WeeklySchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weeklySchedule = await _context.WeeklySchedules.FindAsync(id);
            _context.WeeklySchedules.Remove(weeklySchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeeklyScheduleExists(int id)
        {
            return _context.WeeklySchedules.Any(e => e.ScheduleID == id);
        }
    }
}
