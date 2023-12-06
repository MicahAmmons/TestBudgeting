namespace TestBudgeting.Models
{
    public class ExpenseAndBudgets
    { 
        public Expense Expense { get; set; }
        public Budget  Budget { get; set; }
        IEnumerable<Expense> Expenses { get; set; }
        IEnumerable<Budget> Budgets { get; set; }
    }
}
