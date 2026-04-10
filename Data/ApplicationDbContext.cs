using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProject.Data;
using TestingProject.Models;

namespace TestingProject.Pages
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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
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
