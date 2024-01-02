using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models;
using TestBudgeting.Models.Home;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Home.Reminder;
using TestBudgeting.Models.Home.Budget;



namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReminderMethods repo;
        private readonly IBudgetRepo budgetRepo;
        private readonly IExpenseRepo expenseRepo;

        public HomeController(ReminderMethods repo, IBudgetRepo budgetRepo, IExpenseRepo expenseRepo)
        {
            this.repo = repo;
            this.budgetRepo = budgetRepo;
            this.expenseRepo = expenseRepo;
        }


        public IActionResult HomePage(int month)
        {
            repo.RefreshReminders();
            HomeVar home = WeatherMethods.GetWeather();
            home.Reminders = repo.GetReminders();
            home.DistinctBudgets = budgetRepo.GetDistinctBudget();
            home.TotalMonthlySpent = budgetRepo.GetTotalSpent(month);
            home.TotalMonthlyBudget = budgetRepo.GetMonthlyBudgetTotal(month);
            home.BudgetCollection = budgetRepo.CheckIfSpendingMorethanBudget(month);
            home.MostRecent = expenseRepo.MostRecentExpense();
            return View(home);
        }
        public IActionResult CompleteReminder(int id)
        {
            repo.UpdateRemind(id);
            return new EmptyResult();
        }

        public IActionResult DeleteReminder(int id)
        {
            try
            {
                repo.DeleteReminder(id);
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the reminder: {ex.Message}");
            }
        }

        public IActionResult AddReminder(ReminderV reminder)
        {
                repo.AddReminder(reminder);
                return new EmptyResult(); 
        }
        public IActionResult AddExpense(HomeVar newExpense)
        {
            ExpenseV expense = new ExpenseV() { 
                             Amount = newExpense.Expense.Amount, 
                             Budget = newExpense.Expense.Budget,
                             Payee = newExpense.Expense.Payee,
                             Year = newExpense.Expense.Year,
                             Month = newExpense.Expense.Month,
                             Day = newExpense.Expense.Day,
            };
        repo.InsertExpense(expense);
            return new EmptyResult(); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
