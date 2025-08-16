using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string? q, bool? adultsOnly)
        {
            bool filterAdults = adultsOnly ?? false; // if null (unchecked), treat as false

            IQueryable<Student> query = _context.Students.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var term = q.Trim().ToLower();
                query = query.Where(s => s.FirstName.ToLower().Contains(term) || s.LastName.ToLower().Contains(term));
            }

            if (filterAdults)
            {
                query = query.Where(s => s.Age > 18);
            }

            var totalCount = await _context.Students.CountAsync();
            var adultCount = await _context.Students.CountAsync(s => s.Age > 18);

            var vm = new IndexViewModel
            {
                Students = await query.OrderBy(s => s.FirstName).ThenBy(s => s.LastName).ToListAsync(),
                Search = q,
                AdultsOnly = filterAdults,
                TotalCount = totalCount,
                AdultCount = adultCount
            };

            return View(vm);
        }





        // GET: /Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid) return View(student);

            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Optional: Basic Edit/Delete to round out CRUD
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id) return BadRequest();
            if (!ModelState.IsValid) return View(student);

            _context.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}