using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections.Generic;
using TestBudgeting.Models;


namespace TestBudgeting
{
    public interface IExpenseRepo
    {
        IEnumerable<Expense> GetAllExpenses();
        public void InsertExpense(Expense expenseToInsert);
        IEnumerable<Expense> GetAllExpenses(string budget, int? month);

        IEnumerable<Expense> GetAllExpenses(int? month);

        IEnumerable<Expense> GetAllExpenses(string budget);
        IEnumerable<Expense> GetDistinctBudget();
    }
}