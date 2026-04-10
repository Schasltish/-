using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProlect.Data;
using TestingProlect.Models;
using System.Threading.Tasks;

namespace TestingProlect.Pages
{
    public class CreateTestModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateTestModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string TestName { get; set; } = string.Empty;

        [BindProperty]
        public string Description { get; set; } = string.Empty;

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(TestName))
            {
                return Page();
            }

            var newTest = new Test 
            { 
                Title = TestName, 
                Description = Description 
            };

            _context.Tests.Add(newTest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
