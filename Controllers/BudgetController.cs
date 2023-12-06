using Microsoft.AspNetCore.Mvc;
using System;
using TestBudgeting.Models;

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
            Budget newBud = new Budget();
            return View(newBud);
        }
        public IActionResult InsertBudgetToDatabase(Budget budgetToInsert)
        {
            repo.InsertBudget(budgetToInsert);
            return RedirectToAction("ViewBudgets");
        }
        public IActionResult UpdateBudgetAmountToDatabase(Budget budgetToUpdate)
        {
            repo.UpdateBudgetAmount(budgetToUpdate);
            return RedirectToAction("ViewBudgets");
        }
        public IActionResult UpdateAmount(string id)
        {
            Budget bud = repo.GetBudget(id);
            return View(bud);
        }


    }
}
