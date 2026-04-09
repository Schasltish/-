
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;

public class AccountController : Controller
{
    // Здесь мы подключаем твою базу данных (ApplicationDbContext)
    // чтобы проверять логины и пароли
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Простая проверка: есть ли такой пользователь в таблице "users"
        // В будущем здесь добавим проверку ролей (Преподаватель/Студент)
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View();
    }
}
