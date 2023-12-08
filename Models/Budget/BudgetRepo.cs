using Dapper;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Data;

namespace TestBudgeting.Models.Budget
{
    // Table: expenses
    // Columns: Number - Budget    -    Payee   -   Date   -   Amount
    //         INT     VARCHAR(20)  VARCHAR(30)    DATE    DECIMAL(5,2)
    public class BudgetRepo : IBudgetRepo
    {

        private readonly IDbConnection _conn;

        //Constructor below is to guantee that any instance passes in the connection string 
        public BudgetRepo(IDbConnection conn)
        {
            _conn = conn;
        }


        public double GetTotalBudgetAmount(string budget, int month)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Budget> ViewBudgets()
        {
            // this gets a list of Budgets.DistinctBudgets and Budget.BudgetAmount
            List<Budget> final = new List<Budget>();
            IEnumerable<Budget> budgets = _conn.Query<Budget>("SELECT DistinctBudgets, BudgetAmount FROM budgets;");
            foreach (var budget in budgets)
            {
                IEnumerable<int> allExp = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @current AND Budget = @bud", new { current = budget.CurrentMonth, bud = budget.DistinctBudgets });
                //Add all the Amounts together
                int sum = allExp.Sum();
                //Assign that amount to Budget.TotalSpent
                budget.TotalSpent = sum;
                final.Add(budget);
            }
            //End with an IEnumerable<Budget> with 3 properties, DistinctBudgets, BudgetAmount, TotalSpent
            return budgets;
        }

        public IEnumerable<Budget> InsertBudget(Budget budgetToInsert)
        {
            return _conn.Query<Budget>("INSERT INTO budgets (DistinctBudgets, BudgetAmount) " +
                "VALUES (@DistinctBudgets, @BudgetAmount);",
                      new
                      {
                          DistinctBudgets = budgetToInsert.DistinctBudgets,
                          BudgetAmount = budgetToInsert.BudgetAmount
                      });
        }

        public void UpdateBudgetAmount(Budget budget)
        {
            _conn.Execute("UPDATE budgets SET BudgetAmount = @BudgetAmount WHERE DistinctBudgets = @DistinctBudgets",
                          new
                          {
 
                              BudgetAmount = budget.BudgetAmount,
                              DistinctBudgets = budget.DistinctBudgets
                          });
        }
        public Budget GetBudget(string id)
        {
            return _conn.QuerySingle<Budget>("SELECT * FROM budgets WHERE DistinctBudgets = @distinctBudgets", new { distinctBudgets = id });
        }

        public void DeleteBudget(Budget budget)
        {
            _conn.Execute("DELETE FROM budgets WHERE DistinctBudgets = @id;", 
                new 
                { 
                    id = budget.DistinctBudgets
                });
        }
    }



    //Methods for Queries

}
