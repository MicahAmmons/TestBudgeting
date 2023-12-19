using Microsoft.AspNetCore.Mvc;
using System;
using TestBudgeting.Models.Home.Expense;

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
            ExpenseV exp = repo.GetExpense(id);
            if (exp == null)
            {
                return View("ExpenseNotFound");
            }
            return View(exp);
        }

        public IActionResult UpdateExpenseToDatabase(ExpenseV expense)
        {
            repo.UpdateExpense(expense);
            return RedirectToAction("ViewExpense", new { id = expense.Number });
        }
        public IActionResult DeleteExpense(ExpenseV expense)
        {
            repo.DeleteExpense(expense);
            return RedirectToAction("Index");
        }
        public IActionResult InsertExpense()
        {
            ExpenseV expense = new ExpenseV();
            expense = repo.GetDistinctBudgets();
            return View(expense);
        }

        public IActionResult InsertExpenseToDatabase(ExpenseV expenseToInsert)
        {
            repo.InsertExpense(expenseToInsert);
            return RedirectToAction("Index");
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


