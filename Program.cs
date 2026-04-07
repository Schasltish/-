using Microsoft.EntityFrameworkCore;
using TestingProlect.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы
builder.Services.AddRazorPages();

// Получаем строку подключения из настроек (включая переменные Railway)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=testing.db";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// --- ВОТ ЭТОТ БЛОК СОЗДАСТ ТАБЛИЦЫ ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated(); // Если таблицы нет, она появится
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка при создании базы данных.");
    }
}
// ------------------------------------

// Настройка конвейера
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
