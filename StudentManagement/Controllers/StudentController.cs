using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(Status? filterStatus)
        {
            var results = _context.StudentResults.AsQueryable();

            if (filterStatus != null)
            {
                results = results.Where(r => r.Status == filterStatus);
            }

            var viewModel = new ViewModelForFiltering
            {
                Results = results.ToList(),
                FilterStatus = filterStatus
            };

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student result)
        {
            if (ModelState.IsValid)
            {
                result.Status = result.TotalMarks switch
                {
                    < 50 => Status.NeedsImprovement,
                    <= 80 => Status.Good,
                    _ => Status.Excellent
                };

                _context.StudentResults.Add(result);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(result);
        }

    }
    
    
}
