using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Collections.Generic;

namespace TestBudgeting.Models.Home.Expense
{
    public interface IExpenseRepo
    {
        IEnumerable<ExpenseV> GetAllExpenses();
        public ExpenseV GetExpense(int id);
        public void UpdateExpense(ExpenseV expense);
        public void InsertExpense(ExpenseV expenseToInsert);
        public void DeleteExpense(ExpenseV expense);
        public ExpenseV GetDistinctBudgets();

        public ExpenseV MostRecentExpense();
        public IEnumerable<ExpenseV> UpdateToSearchedExpensesTable(string keyword1, string keyword2, string keyword3, int? month);
        public void DeleteSearchedExpenses();
        public IEnumerable<ExpenseV> ListOfSearchedExpenses();

    }
}