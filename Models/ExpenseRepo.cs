
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestBudgeting.Models
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
                          expenseToInsert.Payee,
                          expenseToInsert.Amount,
                          expenseToInsert.Month,
                          expenseToInsert.Day,
                          expenseToInsert.Year,
                          expenseToInsert.Budget
                      });
        }


        public Expense GetExpense(int id)
        {
           Expense exp = _conn.QuerySingle<Expense>("SELECT * FROM expenses WHERE Number = @number", 
            new 
            { 
                number = id 
            });
           exp.Distinct = _conn.Query<string>("SELECT DistinctBudgets FROM budgets;");
            return exp;
        }
        public void DeleteExpense(Expense expense)
        {
            _conn.Execute("DELETE FROM expenses WHERE Number = @id;", new { id = expense.Number });

        }

        public void UpdateExpense(Expense expense)
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
        public Expense GetDistinctBudgets()
        {
            Expense newE = new Expense();
            newE.Distinct = _conn.Query<string>("SELECT DistinctBudgets FROM budgets;");
            return newE;
        }

        //public double GetTotalBudgetAmount(string budget, int month)
        //{
        //    double totalSpent = 0;
        //    var listOfAmount = _conn.Query<Expense>("SELECT Amount FROM expense WHERE Budget = @budget AND Month = @month", new { Budget = budget, Month = month });

        //    foreach (var item in listOfAmount)
        //    {
        //        totalSpent += item.Amount;
        //    }
        //    return totalSpent;
        //}
    }
}