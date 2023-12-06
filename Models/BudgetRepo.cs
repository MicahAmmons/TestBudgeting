using Dapper;
using System.Collections.Generic;
using System.Data;

namespace TestBudgeting.Models
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
            return _conn.Query<Budget>("SELECT * FROM budgets;");
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

    }



    //Methods for Queries

}
