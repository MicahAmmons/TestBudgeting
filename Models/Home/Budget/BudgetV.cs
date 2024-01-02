// Table: expenses
// Columns: Number - Budget    -    Payee   -   Year  Month  Day   -   Amount
//         INT     VARCHAR(20)  VARCHAR(30)    DATE    DECIMAL(5,2)

namespace TestBudgeting.Models.Home.Budget
{
    public class BudgetV
    {

        public double BudgetAmount { get; set; }
        public string DistinctBudgets { get; set; }
        public int Month { get; set; } 
        public double TotalSpent { get; set; }
        public double IdealSpendage { get; set; }
        public double Number { get; set; }







    }
}


// New budget buttons
// view budgets - > 
// for each loop in the view that created a table per budget
// Update budget hyperlink somewhere in the individual tables 