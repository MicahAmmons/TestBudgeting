namespace TestBudgeting.Models.Home.Budget
{
    public interface IBudgetRepo
    {
        public IEnumerable<BudgetV> ViewBudgets(int month);
        public IEnumerable<BudgetV> InsertBudget(BudgetV budgetToInsert);
        public void UpdateBudgetAmount(BudgetV budget);
        public BudgetV GetBudget(double id);
        public void DeleteBudget(BudgetV bud);
        public IEnumerable<string> GetDistinctBudget();
        public double GetTotalSpent(int month);
        public double GetMonthlyBudgetTotal(int month);
        public IEnumerable<BudgetV> CheckIfSpendingMorethanBudget(int month);
        public HomeVar MonthlyIncomeBudgetSpending(HomeVar home, int month);
        


    }
}
