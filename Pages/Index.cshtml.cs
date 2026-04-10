using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProlect.Data;
using TestingProlect.Models;
using Microsoft.EntityFrameworkCore;

namespace TestingProlect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TestResult> AllResults { get; set; } = new();
        public List<Test> AvailableTests { get; set; } = new();

        public void OnGet()
        {
            // Получаем результаты для таблицы преподавателя
            AllResults = _context.TestResults
                .OrderByDescending(r => r.TestDate)
                .ToList();

            // Получаем список созданных тестов для студентов
            AvailableTests = _context.Tests
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }
    }
}
