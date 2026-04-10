using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProject.Data; 
using TestingProject.Models;
using System.Threading.Tasks;

namespace TestingProject.Pages
{
    public class CreateTestModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateTestModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync(string TestName, string Description)
        {
            var newTest = new Test { Title = TestName, Description = Description };
            _context.Tests.Add(newTest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
