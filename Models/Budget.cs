// Table: expenses
// Columns: Number - Budget    -    Payee   -   Year  Month  Day   -   Amount
//         INT     VARCHAR(20)  VARCHAR(30)    DATE    DECIMAL(5,2)

namespace TestBudgeting.Models
{
    public class Budget
    {

        public double BudgetAmount { get; set; }
        public string DistinctBudgets { get; set; }
        public int CurrentMonth { get; set; } = DateTime.Now.Month;

    }
}


// New budget buttons
// view budgets - > 
// for each loop in the view that created a table per budget
// Update budget hyperlink somewhere in the individual tables 