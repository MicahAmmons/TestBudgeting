using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections.Generic;
using TestBudgeting.Models;


namespace TestBudgeting
{
    public interface IExpenseRepo
    {
        IEnumerable<Expense> GetAllExpenses();
        public Expense GetExpense(int id);
        public void UpdateExpense(Expense expense);
        public void InsertExpense(Expense expenseToInsert);
        public void DeleteExpense(Expense product);
        public double GetTotalBudgetAmount(string budget, int month);
        public IEnumerable<Expense> GetDistinctBudgets();
    }
}