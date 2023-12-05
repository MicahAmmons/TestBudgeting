
using Dapper;
using System.Data;
using System.Collections.Generic;

using TestBudgeting.Models;
using TestBudgeting;

namespace BudgetAppProject
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
        public IEnumerable<Expense> GetAllExpenses()

        {
            return _conn.Query<Expense>("SELECT * FROM expenses;");
        }



        public IEnumerable<Expense> GetAllExpenses(string budget, int? month)
        {
            return _conn.Query<Expense>("SELECT * FROM expenses WHERE Budget = @budget AND Month = @month;",
                new { budget = budget, month = month });
        }
        public IEnumerable<Expense> GetAllExpenses(int? month)
        {
            return _conn.Query<Expense>("SELECT * FROM expenses WHERE Month = @month;",
             new { month = month });
        }
        public IEnumerable<Expense> GetAllExpenses(string budget)
        {
            return _conn.Query<Expense>("SELECT * FROM expenses WHERE Budget = @budget;",
             new { budget = budget });
        }

        public IEnumerable<Expense> GetDistinctBudget()
        {
            return _conn.Query<Expense>("SELECT DISTINCT budget FROM expenses;");
        }


        public void InsertExpense(Expense expenseToInsert)
        {

            _conn.Execute("INSERT INTO expenses (Payee, Amount, Month, Day, Year, Budget) " +
                "VALUES (@Payee, @Amount, @Month, @Day, @Year, @Budget);",
                      new
                      {
                          Payee = expenseToInsert.Payee,
                          Amount = expenseToInsert.Amount,
                          Month = expenseToInsert.Month,
                          Day = expenseToInsert.Day,
                          Year = expenseToInsert.Year,
                          Budget = expenseToInsert.Budget
                      });
        }
        public IEnumerable<Expense> GetSpecificBudget(string budget, int month)
        {
            if (budget == "All")
            {
                var budgets = budget;
                return _conn.Query<Expense>("SELECT * FROM expenses WHERE Month = @month;",
                 new { month = month });
            }
            else
            {
                return _conn.Query<Expense>("SELECT * FROM expenses WHERE Budget = @budget && Month = @month;",
                    new { budget = budget, month = month });
            }
        }
    }
}