using MySql.Data.MySqlClient;
using System.Data;
using TestBudgeting.Models.Home.Budget;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Home.Reminder;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("azure"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IExpenseRepo, ExpenseRepo>();
builder.Services.AddTransient<IBudgetRepo, BudgetRepo>();
builder.Services.AddTransient<ReminderMethods>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginPage}/{id?}");

app.Run();