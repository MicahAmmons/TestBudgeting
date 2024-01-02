using Microsoft.AspNetCore.Mvc;
using System;
using TestBudgeting.Models;
using TestBudgeting.Models.Home;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Home.Reminder;
using TestBudgeting.Models.Home.Budget;
using System.Collections.Generic;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace BudgetAppProject.Controllers
{
    public class BudgetController : Controller
    {

        private readonly IBudgetRepo repo;
        private readonly IExpenseRepo expenseRepo;

        public BudgetController(IBudgetRepo repo, IExpenseRepo expenseRepo)
        {
            this.repo = repo;
            this.expenseRepo = expenseRepo;
        }

        public IActionResult ViewBudgets(int month)
        {
            HomeVar home = new HomeVar();
            home.BudgetCollection = repo.ViewBudgets(month);
            home = repo.MonthlyIncomeBudgetSpending(home, month);
            home.ExpenseCollection = expenseRepo.GetAllExpenses(month);

            return View(home);
        }
        public IActionResult InsertBudget()
        {
            BudgetV newBud = new BudgetV();
            return View(newBud);
        }
        public IActionResult InsertBudgetToDatabase(BudgetV budgetToInsert)
        {
            repo.InsertBudget(budgetToInsert);
            return RedirectToAction("ViewBudgets");
        }
        public IActionResult UpdateBudgetAmountToDatabase(BudgetV budget)
        {
            repo.UpdateBudgetAmount(budget);
            return RedirectToAction("ViewBudgets");
        }
        public IActionResult UpdateAmount(double id)
        {
            BudgetV bud = repo.GetBudget(id);
            return View(bud);
        }
        public IActionResult DeleteBudget(BudgetV bud)
        {
            repo.DeleteBudget(bud);
            return RedirectToAction("ViewBudgets");
        }



    }
}
