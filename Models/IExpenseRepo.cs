using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections.Generic;

namespace TestBudgeting.Models
{
    public interface IExpenseRepo
    {
        IEnumerable<Expense> GetAllExpenses();
        public Expense GetExpense(int id);
        public void UpdateExpense(Expense expense);
        public void InsertExpense(Expense expenseToInsert);
        public void DeleteExpense(Expense product);
        public Expense GetDistinctBudgets();

    }
}