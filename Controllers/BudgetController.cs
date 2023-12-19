using Microsoft.AspNetCore.Mvc;
using System;
using TestBudgeting.Models;
using TestBudgeting.Models.Home.Budget;

namespace BudgetAppProject.Controllers
{
    public class BudgetController : Controller
    {

        private readonly IBudgetRepo repo;

        public BudgetController(IBudgetRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult ViewBudgets()
        {
            var bud = repo.ViewBudgets();
            return View(bud);
        }
        public IActionResult CheckBudget()
        {
            throw new NotImplementedException();    
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

    }
}
