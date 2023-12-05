
using Dapper;
using System.Data;
using System.Collections.Generic;

using TestBudgeting.Models;
using TestBudgeting;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IEnumerable<Expense> UpdateExpense(Expense expenseToUpdate)
        {
            return _conn.Query<Expense>("UPDATE products SET Payee = @payee, Amount = @Amount, Month = @month, Day = @day, Year = @year, Budget = @budget WHERE Number = @number;",
                                     new
                                     {
                                         Payee = expenseToUpdate.Payee,
                                         Amount = expenseToUpdate.Amount,
                                         Month = expenseToUpdate.Month,
                                         Day = expenseToUpdate.Day,
                                         Year = expenseToUpdate.Year,
                                         Budget = expenseToUpdate.Budget
                                     });

        }
        public Expense GetExpense(int number)
        {
            return _conn.QuerySingle<Expense>("SELECT * FROM expenses WHERE Number = @number" , new { number = number });
        }
        public void DeleteExpense(Expense expense)
        {
            _conn.Execute("DELETE FROM expenses WHERE Number = @number;", new { id = expense.Number });

        }

        public void UpdateProduct(Expense expense)
        {
            _conn.Execute("UPDATE expenses SET Payee = @payee, Amount = @Amount Budget = @budget, Month = @month, Day = @day, Year = @year WHERE Number = @number",
                                      new
                                      {
                                          Payee = expense.Payee,
                                          Amount = expense.Amount,
                                          Month = expense.Month,
                                          Day = expense.Day,
                                          Year = expense.Year,
                                          Budget = expense.Budget
                                      });
        }

        public double GetTotalBudgetAmount(string budget, int month)
        {
            double totalSpent = 0;
            var listOfAmount = _conn.Query<Expense>("SELECT Amount FROM expense WHERE Budget = @budget AND Month = @month", new { Budget = budget, Month = month });

            foreach (var item in listOfAmount )
            {
                totalSpent += item.Amount;
            }
            return totalSpent;
        }

        public IEnumerable<Expense> GetDistinctBudgets()
        {

            return _conn.Query<Expense>("SELECT DISTINCT Budget FROM expenses; ");
        }
    }
}