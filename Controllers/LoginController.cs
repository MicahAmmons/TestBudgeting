using Going.Plaid.Entity;
using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models;
using TestBudgeting.Models.Home.Budget;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Login;

namespace TestBudgeting.Controllers
{
    public class LoginController : Controller
    {
        private readonly IBudgetRepo repo;
        private readonly IExpenseRepo expenseRepo;

        public LoginController(IBudgetRepo repo, IExpenseRepo expenseRepo)
        {
            this.repo = repo;
            this.expenseRepo = expenseRepo;
        }
        public IActionResult LoginPage()
        {
            Login login = new Login();
            expenseRepo.DeleteSearchedExpenses();
            return View(login);
        }
        [HttpPost]
        public IActionResult LoginCall(Login login) 
        {
            bool success = LoginMethods.LoginAttempt(login);
            if (success == true)
            {
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("LoginPage", "Login");
            }
        }
    }
}
