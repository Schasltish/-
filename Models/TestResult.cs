using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProject.Models;
using TestingProject.Data; // Убедись, что папка с контекстом называется Data
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

        [BindProperty]
        public string TestName { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Создаем новый объект теста
            // ВАЖНО: Проверь, как называются поля в твоем файле Test.cs
            var newTest = new Test 
            { 
                Title = TestName, 
                Description = Description 
            };

            _context.Tests.Add(newTest);
            await _context.SaveChangesAsync();

            // Перенаправляем на страницу добавления вопросов к этому тесту
            return RedirectToPage("./Index"); 
        }
    }
}
