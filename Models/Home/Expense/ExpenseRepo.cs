
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestBudgeting.Models.Home.Expense
{
    // Table: expenses
    // Columns: Number - Budget    -    Payee   -   Date   -   Amount
    //         INT     VARCHAR(20)  VARCHAR(30)    DATE    DECIMAL(5,2)
    public class ExpenseRepo : IExpenseRepo
    {

        private readonly IDbConnection _conn;

        //Constructor below is to guantee that any instance passes in the connection string 
        public ExpenseRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        //Methods for Queries
        public IEnumerable<ExpenseV> GetAllExpenses()

        {
            return _conn.Query<ExpenseV>("SELECT * FROM expenses;");
        }
        public IEnumerable<ExpenseV> GetAllExpensesOfSpecificType(string budget)
        {
            return _conn.Query<ExpenseV>("SELECT * FROM expenses WHERE Budget = @budget;", new {budget = budget});
        }

        public void InsertExpense(ExpenseV expenseToInsert)
        {

            _conn.Execute("INSERT INTO expenses (Payee, Amount, Month, Day, Year, Budget) " +
                "VALUES (@Payee, @Amount, @Month, @Day, @Year, @Budget);",
                      new
                      {
                          expenseToInsert.Payee,
                          expenseToInsert.Amount,
                          expenseToInsert.Month,
                          expenseToInsert.Day,
                          expenseToInsert.Year,
                          expenseToInsert.Budget
                      });
        }


        public ExpenseV GetExpense(int id)
        {
            ExpenseV exp = _conn.QuerySingle<ExpenseV>("SELECT * FROM expenses WHERE Number = @number",
             new
             {
                 number = id
             });
            exp.Distinct = _conn.Query<string>("SELECT DistinctBudgets FROM budgets;");
            return exp;
        }

        public void DeleteExpense(ExpenseV expense)
        {
            _conn.Execute("DELETE FROM expenses WHERE Number = @id;", new { id = expense.Number });

        }

        public void UpdateExpense(ExpenseV expense)
        {
            _conn.Execute("UPDATE expenses SET Payee = @payee, Amount = @Amount, Budget = @budget, Month = @month, Day = @day, Year = @year WHERE Number = @number",
                                      new
                                      {
                                          expense.Payee,
                                          expense.Amount,
                                          expense.Month,
                                          expense.Day,
                                          expense.Year,
                                          expense.Budget,
                                          expense.Number
                                      });
        }
        public ExpenseV GetDistinctBudgets()
        {
            ExpenseV newE = new ExpenseV();
            newE.Distinct = _conn.Query<string>("SELECT DistinctBudgets FROM budgets;");
            return newE;
        }

        public ExpenseV MostRecentExpense()
        {
            ExpenseV expense = new ExpenseV();
            expense = _conn.Query<ExpenseV>("SELECT * FROM expenses ORDER BY Year DESC, Month DESC, Day DESC, Number DESC LIMIT 1; ").FirstOrDefault();
            return expense;
        }
    }
}