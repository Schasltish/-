using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProlect.Data;
using TestingProlect.Models;

namespace TestingProlect.Pages
{
    public class CreateTestModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateTestModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Test NewTest { get; set; } = new();

        // Сюда придут вопросы из формы
        [BindProperty]
        public List<QuestionViewModel> Questions { get; set; } = new();

        public void OnGet() {}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!Questions.Any()) return Page();

            // Создаем тест
            var test = new Test
            {
                Title = NewTest.Title,
                Description = NewTest.Description,
                CreatedAt = DateTime.Now
            };

            foreach (var q in Questions)
            {
                var question = new Question { Text = q.Text };
                foreach (var opt in q.Options)
                {
                    question.Options.Add(new AnswerOption 
                    { 
                        Text = opt.Text, 
                        IsCorrect = opt.IsCorrect 
                    });
                }
                test.Questions.Add(question);
            }

            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    // Вспомогательные классы для формы
    public class QuestionViewModel
    {
        public string Text { get; set; } = "";
        public List<OptionViewModel> Options { get; set; } = new();
    }

    public class OptionViewModel
    {
        public string Text { get; set; } = "";
        public bool IsCorrect { get; set; }
    }
}
