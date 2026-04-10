using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourProjectName.Data; // Замени на свое пространство имен
using YourProjectName.Models;

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

        // После создания теста перекидываем на добавление вопросов к нему
        return RedirectToPage("./AddQuestions", new { id = newTest.Id });
    }
}

