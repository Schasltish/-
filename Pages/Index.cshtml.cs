using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProlect.Data;
using TestingProlect.Models;
using Microsoft.EntityFrameworkCore;

namespace TestingProlect.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TestResult> AllResults { get; set; } = new();

        public void OnGet()
        {
            AllResults = _context.TestResults.OrderByDescending(r => r.TestDate).ToList();
        }

        public IActionResult OnPostSaveResult([FromBody] TestResult result)
        {
            if (result == null) return BadRequest();

            _context.TestResults.Add(result);
            _context.SaveChanges();
            
            return new JsonResult(new { success = true });
        }
    }
}
