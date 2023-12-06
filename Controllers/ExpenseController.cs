using Microsoft.AspNetCore.Mvc;
using System;
using TestBudgeting.Models;

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
        public IActionResult ViewExpense(int id)
        {
            var expense = repo.GetExpense(id);
            return View(expense);
        }
        public IActionResult UpdateExpense(int id)
        {
            Expense exp = repo.GetExpense(id);
            if (exp == null)
            {
                return View("ExpenseNotFound");
            }
            return View(exp);
        }

        public IActionResult UpdateExpenseToDatabase(Expense expense)
        {
            repo.UpdateExpense(expense);
            return RedirectToAction("ViewExpense", new { id = expense.Number });
        }
        public IActionResult DeleteExpense(Expense expense)
        {
            repo.DeleteExpense(expense);
            return RedirectToAction("Index");
        }
        public IActionResult InsertExpense()
        {
            Expense expense = new Expense();
            return View(expense);
        }

        public IActionResult InsertExpenseToDatabase(Expense expenseToInsert)
        {
            repo.InsertExpense(expenseToInsert);
            return RedirectToAction("ViewBudgets");
        }

    }
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


