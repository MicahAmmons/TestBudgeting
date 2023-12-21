using Microsoft.AspNetCore.Mvc;
using System;
using TestBudgeting.Models;
using TestBudgeting.Models.Home;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Home.Reminder;
using TestBudgeting.Models.Home.Budget;
using System.Collections.Generic;

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

        public IActionResult ViewBudgets()
        {
            HomeVar home = new HomeVar();
            home.BudgetCollection = repo.ViewBudgets();
            home = repo.MonthlyIncomeBudgetSpending(home);
            home.ExpenseCollection = expenseRepo.GetAllExpenses();

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
        public IActionResult UpdateBudgetAmountToDatabase(BudgetV budgetToUpdate)
        {
            repo.UpdateBudgetAmount(budgetToUpdate);
            return RedirectToAction("ViewBudgets");
        }
        public IActionResult UpdateAmount(string id)
        {
            BudgetV bud = repo.GetBudget(id);
            return View(bud);
        }
        public IActionResult DeleteBudget(BudgetV budget)
        {
            repo.DeleteBudget(budget);
            var ex = repo.ViewBudgets();
            return RedirectToAction("ViewBudgets", ex);
        }
        public IActionResult UpdateExpensesPerBudget(string budget)
        {
            throw new NotImplementedException();
        }

    }
}
