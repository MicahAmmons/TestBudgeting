﻿// Table: expenses
// Columns: Number - Budget    -    Payee   -   Year  Month  Day   -   Amount
//         INT     VARCHAR(20)  VARCHAR(30)    DATE    DECIMAL(5,2)

namespace TestBudgeting.Models.Home.Expense
{
    public class ExpenseV
    {

        public double Amount { get; set; }
        public string Payee { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Budget { get; set; } = string.Empty;
        public int Number { get; set; }
        public IEnumerable<string> Distinct { get; set; }
        public int CurrentMonth { get; set; } = DateTime.Now.Month;
        public double TotalSpentByPayeeAndMonth { get; set; }




    }
}
