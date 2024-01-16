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

        public IEnumerable<BudgetV> ViewBudgets(int month)
        {
            int currentMonth = GetMonth(month);
            // this gets a list of Budgets.DistinctBudgets and Budget.BudgetAmount
            List<BudgetV> final = new List<BudgetV>();
            IEnumerable<BudgetV> budgets = _conn.Query<BudgetV>("SELECT DistinctBudgets, BudgetAmount, Month, Number FROM budgets WHERE DistinctBudgets != 'Income' AND Month = @currentMonth;",
                new {currentMonth = currentMonth});
            foreach (var budget in budgets)
            {
                IEnumerable<int> allExp = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @current AND Budget = @bud", new { current = currentMonth, bud = budget.DistinctBudgets });
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
            return _conn.Query<BudgetV>("INSERT INTO budgets (DistinctBudgets, BudgetAmount, Month) " +
                "VALUES (@DistinctBudgets, @BudgetAmount, @Month);",
                      new
                      {
                          budgetToInsert.DistinctBudgets,
                          budgetToInsert.BudgetAmount,
                          budgetToInsert.Month
                      });
        }

        public void UpdateBudgetAmount(BudgetV budget)
        {
            _conn.Execute("UPDATE budgets SET BudgetAmount = @budgetamount WHERE Number = @id",
                          new
                          {
                              budgetamount = budget.BudgetAmount,
                              id = budget.Number
                          });
        }
        public BudgetV GetBudget(double id)
        {
            return _conn.QuerySingle<BudgetV>("SELECT * FROM budgets WHERE Number = @id", new { id = id });
        }

        public void DeleteBudget(BudgetV bud)
        {
            _conn.Execute("DELETE FROM budgets WHERE Number = @id;",
                new
                {
                    id = bud.Number
                });
        }

        public IEnumerable<string> GetDistinctBudget()
        {
            IEnumerable<string> budgets = _conn.Query<string>("SELECT DISTINCT DistinctBudgets FROM budgets ORDER BY DistinctBudgets;");
            return budgets;
        }
        public double GetTotalSpent(int month) //specific budget
        {
            int currentMonth = GetMonth(month);
            IEnumerable<int> allExp = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @month AND Budget != 'Internet' AND Budget != 'Income' AND Budget != 'Rent' AND Budget != 'Electric/Gas';", new
            {
                month = currentMonth
            });
            double final = allExp.Sum();
            return final;
        }
        public double GetMonthlyBudgetTotal(int month) //excludes rent, internet, utitlites
        {
            int currentMonth = GetMonth(month);
            IEnumerable<int> allExp = _conn.Query<int>("SELECT BudgetAmount FROM budgets WHERE DistinctBudgets != 'Internet' AND DistinctBudgets != 'Income' AND DistinctBudgets != 'Rent' AND DistinctBudgets != 'Electric/Gas';");
            double final = allExp.Sum();
            return final;
        }

        public IEnumerable<BudgetV> CheckIfSpendingMorethanBudget(int month) //returns a list of Budgets ONLY if the spending is more than it should be
        {
            int currentMonth = GetMonth(month);
            List<BudgetV> budgetList = new List<BudgetV>();
            List<BudgetV> returnList = new List<BudgetV>();
            IEnumerable<BudgetV> budgets = _conn.Query<BudgetV>("SELECT DistinctBudgets, BudgetAmount FROM budgets WHERE BudgetAmount != 0 AND DistinctBudgets IN ('Food', 'Date Night', 'Groceries', 'Misc.', 'Pet') AND Month = @month;", new {month = currentMonth});
            foreach (var budget in budgets)
            {
                IEnumerable<double> allExp = _conn.Query<double>("SELECT Amount FROM expenses WHERE Month = @current AND Budget = @bud", new { current = currentMonth, bud = budget.DistinctBudgets });
                //Add all the Amounts together
                double sum = allExp.Sum();
                //Assign that amount to Budget.TotalSpent
                budget.TotalSpent = Math.Round(sum, 2);
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
                totalMonthlyAmount = budget.BudgetAmount * percentage;
                if (totalMonthlyAmount < budget.TotalSpent) 
                {
                    budget.IdealSpendage = Math.Round(totalMonthlyAmount, 2);
                    returnList.Add(budget);
                }
            }
            return returnList;
        }
        public HomeVar MonthlyIncomeBudgetSpending(HomeVar home, int month)
        {
            int currentMonth = GetMonth(month);
            IEnumerable<int> allExp = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @current AND Budget = 'Income';", new { current = currentMonth });
            int sum = allExp.Sum();
            home.MonthlyIncome = sum;
            //total monthly budget
            IEnumerable<int> allBud = _conn.Query<int>("SELECT SUM(BudgetAmount) AS TotalBudgetAmount FROM budgets WHERE DistinctBudgets != 'Income' AND Month = @month;", new {month = currentMonth});
            home.TotalMonthlyBudget = allBud.Sum(); ;
            //total monthly spent
            IEnumerable<int> allSpent = _conn.Query<int>("SELECT Amount FROM expenses WHERE Month = @month AND Budget != 'Income';", new {month = currentMonth});
            home.TotalMonthlySpent = allSpent.Sum();
            return home;
        }

        public int GetMonth(int month)
        {
            if (month == 0)
            {
                return DateTime.Now.Month;
            }
            return month;
        }

        public int GetMonth()
        {
                return DateTime.Now.Month;
        }
    }



    //Methods for Queries

}
