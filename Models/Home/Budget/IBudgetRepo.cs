namespace TestBudgeting.Models.Home.Budget
{
    public interface IBudgetRepo
    {
        public IEnumerable<BudgetV> ViewBudgets();
        public IEnumerable<BudgetV> InsertBudget(BudgetV budgetToInsert);
        public void UpdateBudgetAmount(BudgetV budget);
        public BudgetV GetBudget(string id);
        public void DeleteBudget(BudgetV budget);
        public IEnumerable<string> GetDistinctBudget();
        public double GetTotalSpent();
        public double GetMonthlyBudgetTotal();
        public IEnumerable<BudgetV> CheckIfSpendingMorethanBudget();
        public HomeVar MonthlyIncomeBudgetSpending(HomeVar home);
        


    }
}
