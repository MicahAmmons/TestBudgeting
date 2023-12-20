using Dapper;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Data;

namespace TestBudgeting.Models.Home.Budget
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

        public IEnumerable<BudgetV> ViewBudgets()
        {
            // this gets a list of Budgets.DistinctBudgets and Budget.BudgetAmount
            List<BudgetV> final = new List<BudgetV>();
            IEnumerable<BudgetV> budgets = _conn.Query<BudgetV>("SELECT DistinctBudgets, BudgetAmount FROM budgets;");
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

        public IEnumerable<BudgetV> InsertBudget(BudgetV budgetToInsert)
        {
            return _conn.Query<BudgetV>("INSERT INTO budgets (DistinctBudgets, BudgetAmount) " +
                "VALUES (@DistinctBudgets, @BudgetAmount);",
                      new
                      {
                          budgetToInsert.DistinctBudgets,
                          budgetToInsert.BudgetAmount
                      });
        }

        public void UpdateBudgetAmount(BudgetV budget)
        {
            _conn.Execute("UPDATE budgets SET BudgetAmount = @BudgetAmount WHERE DistinctBudgets = @DistinctBudgets",
                          new
                          {

                              budget.BudgetAmount,
                              budget.DistinctBudgets
                          });
        }
        public BudgetV GetBudget(string id)
        {
            return _conn.QuerySingle<BudgetV>("SELECT * FROM budgets WHERE DistinctBudgets = @distinctBudgets", new { distinctBudgets = id });
        }

        public void DeleteBudget(BudgetV budget)
        {
            _conn.Execute("DELETE FROM budgets WHERE DistinctBudgets = @id;",
                new
                {
                    id = budget.DistinctBudgets
                });
        }

        public IEnumerable<string> GetDistinctBudget()
        {
            IEnumerable<string> budgets = _conn.Query<string>("SELECT DistinctBudgets FROM budgets;");
            return budgets;
        }
        public double GetTotalSpent()
        {
            int currentMonth = DateTime.Now.Month;
            IEnumerable<int> allExp = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @month AND Budget != 'Internet' AND Budget != 'Income' AND Budget != 'Rent' AND Budget != 'Electric/Gas';", new
            {
                month = currentMonth
            });
            double final = allExp.Sum();
            return final;
        }
        public double GetMonthlyBudgetTotal()
        {
            int currentMonth = DateTime.Now.Month;
            IEnumerable<int> allExp = _conn.Query<int>("SELECT BudgetAmount FROM budgets WHERE DistinctBudgets != 'Internet' AND DistinctBudgets != 'Income' AND DistinctBudgets != 'Rent' AND DistinctBudgets != 'Electric/Gas';");
            double final = allExp.Sum();
            return final;
        }

        public IEnumerable<BudgetV> CheckIfSpendingMorethanBudget()
        {
            List<BudgetV> budgetList = new List<BudgetV>();
            List<BudgetV> returnList = new List<BudgetV>();
            IEnumerable<BudgetV> budgets = _conn.Query<BudgetV>("  SELECT DistinctBudgets, BudgetAmount FROM budgets WHERE BudgetAmount != 0;");
            foreach (var budget in budgets)
            {
                IEnumerable<int> allExp = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @current AND Budget = @bud", new { current = budget.CurrentMonth, bud = budget.DistinctBudgets });
                //Add all the Amounts together
                int sum = allExp.Sum();
                //Assign that amount to Budget.TotalSpent
                budget.TotalSpent = sum;
                budgetList.Add(budget);
            }
            DateTime currentDate = DateTime.Now;
            // Get the number of days in the current month
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            // Calculate the percentage
            double percentage = (double)currentDate.Day / daysInMonth;

            foreach (var budget in budgetList)
            {
                double totalMonthlyAmount;
                double totalSpent;
                totalMonthlyAmount = budget.BudgetAmount * percentage;
                totalSpent = budget.TotalSpent * percentage;
                if (totalMonthlyAmount < totalSpent) 
                {
                    budget.IdealSpendage = Math.Round(totalMonthlyAmount, 2);
                    returnList.Add(budget);
                }
            }
            return returnList;

            //.TotalSpent
            //.BudgetTotal
            //.BudgetName



        }
    }



    //Methods for Queries

}
