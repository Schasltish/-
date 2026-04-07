using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingProlect.Data;
using TestingProlect.Models;
using Microsoft.EntityFrameworkCore;

namespace TestingProlect.Pages
{
    // [IgnoreAntiforgeryToken] нужен, чтобы JavaScript мог отправлять данные в базу без ошибок безопасности
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Конструктор: подключаем нашу базу данных
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Список для хранения истории (нужен для панели преподавателя)
        public List<TestResult> AllResults { get; set; } = new();

        public void OnGet()
        {
            // Когда страница открывается, загружаем список всех результатов из базы
            AllResults = _context.TestResults.OrderByDescending(r => r.TestDate).ToList();
        }

        // Этот метод вызывается из JavaScript, когда студент нажимает "Завершить тест"
        public IActionResult OnPostSaveResult([FromBody] TestResult result)
        {
            if (result == null) return BadRequest();

            // Добавляем запись в таблицу и сохраняем файл .db
            _context.TestResults.Add(result);
            _context.SaveChanges();
            
            return new JsonResult(new { success = true });
        }
    }
}
