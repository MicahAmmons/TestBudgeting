using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models;
using TestBudgeting;
using System;

namespace BudgetAppProject.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly IExpenseRepo repo;

        public ExpenseController(IExpenseRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
                var exp = repo.GetAllExpenses();
                return View(exp);
        }
        public IActionResult InsertExpense()
        {
            Expense expense = new Expense();
            return View(expense);
        }
        public IActionResult InsertExpenseToDatabase(Expense expense)
        {
            repo.InsertExpense(expense);
            return RedirectToAction("Index");

        }


        //public IActionResult Index()
        //{
        //    var expenses = repo.GetAllExpenses();
        //    return View(expenses);
        //}
        //public IActionResult Index(string budget)
        //{
        //    var expenses = repo.GetAllExpenses(budget);
        //    return View(expenses);
        //}
        //public IActionResult Index(string budget, int month)
        //{
        //    var expenses = repo.GetAllExpenses(budget, month);
        //    return View(expenses);
        //}
        //public IActionResult Index(int month)
        //{
        //    var expenses = repo.GetAllExpenses(month);
        //    return View(expenses);
        //}

        //        {
           

//            if (string.IsNullOrEmpty(budget) && month.HasValue)
//            {
//                var exp = repo.GetAllExpenses(month);
//                return View(exp);
//    }
//            if (!string.IsNullOrEmpty(budget) && !month.HasValue)
//            {
//                var exp = repo.GetAllExpenses(budget);
//                return View(exp);
//}
//            else
//{
//    var exp = repo.GetAllExpenses(budget, month);
//    return View(exp);
//}
//        }
    }
}


