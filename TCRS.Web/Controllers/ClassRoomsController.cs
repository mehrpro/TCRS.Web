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
    public class ClassRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassRooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClassRooms.Include(c => c.Lesson).Include(c => c.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms
                .Include(c => c.Lesson)
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.ClassID == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public IActionResult Create()
        {
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle");
            ViewData["PersonID_FK"] = new SelectList(_context.People, "Id", "Id");
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassID,PersonID_FK,LessonID_FK,StudentNumber,IsActive,RegisterDate")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle", classRoom.LessonID_FK);
            ViewData["PersonID_FK"] = new SelectList(_context.People, "Id", "Id", classRoom.PersonID_FK);
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle", classRoom.LessonID_FK);
            ViewData["PersonID_FK"] = new SelectList(_context.People, "Id", "Id", classRoom.PersonID_FK);
            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassID,PersonID_FK,LessonID_FK,StudentNumber,IsActive,RegisterDate")] ClassRoom classRoom)
        {
            if (id != classRoom.ClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoomExists(classRoom.ClassID))
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
            ViewData["LessonID_FK"] = new SelectList(_context.Lessons, "LessonID", "LessonTitle", classRoom.LessonID_FK);
            ViewData["PersonID_FK"] = new SelectList(_context.People, "Id", "Id", classRoom.PersonID_FK);
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms
                .Include(c => c.Lesson)
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.ClassID == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classRoom = await _context.ClassRooms.FindAsync(id);
            _context.ClassRooms.Remove(classRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRooms.Any(e => e.ClassID == id);
        }
    }
}
