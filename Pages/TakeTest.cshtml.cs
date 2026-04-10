using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingProlect.Data;
using TestingProlect.Models;

namespace TestingProlect.Pages
{
    public class TakeTestModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public TakeTestModel(ApplicationDbContext context) => _context = context;

        public Test CurrentTest { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Загружаем тест вместе с вопросами и вариантами ответов
            var test = await _context.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (test == null) return RedirectToPage("./Index");

            CurrentTest = test;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int testId, Dictionary<int, int> answers, string studentName, string groupName)
        {
            var test = await _context.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null) return RedirectToPage("./Index");

            int score = 0;
            foreach (var question in test.Questions)
            {
                if (answers.TryGetValue(question.Id, out int selectedOptionId))
                {
                    var correctOption = question.Options.FirstOrDefault(o => o.IsCorrect);
                    if (correctOption != null && correctOption.Id == selectedOptionId)
                    {
                        score++;
                    }
                }
            }

            var result = new TestResult
            {
                StudentName = studentName,
                GroupName = groupName,
                Score = score,
                TotalQuestions = test.Questions.Count,
                TestDate = DateTime.Now
            };

            _context.TestResults.Add(result);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
