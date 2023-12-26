using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Home;
using TestBudgeting.Models.Home.Budget;
using TestBudgeting.Models.Home.Reminder;

namespace TestBudgeting.Controllers
{
    public class SearchController : Controller
    {
        private readonly ReminderMethods repo;
        private readonly IBudgetRepo budgetRepo;
        private readonly IExpenseRepo expenseRepo;

        public SearchController(ReminderMethods repo, IBudgetRepo budgetRepo, IExpenseRepo expenseRepo)
        {
            this.repo = repo;
            this.budgetRepo = budgetRepo;
            this.expenseRepo = expenseRepo;
        }
        public IActionResult Search(string keyword1, string keyword2, string keyword3, int? month)
        {
            HomeVar home = new HomeVar();
            home.ExpensesByPayeeandMonth = expenseRepo.UpdateToSearchedExpensesTable(keyword1, keyword2, keyword3, month);
            return View(home);
        }
    }
}
