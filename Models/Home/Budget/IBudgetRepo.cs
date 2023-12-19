namespace TestBudgeting.Models.Home.Budget
{
    public interface IBudgetRepo
    {
        public double GetTotalBudgetAmount(string budget, int month);
        public IEnumerable<BudgetV> ViewBudgets();
        public IEnumerable<BudgetV> InsertBudget(BudgetV budgetToInsert);
        public void UpdateBudgetAmount(BudgetV budget);
        public BudgetV GetBudget(string id);
        public void DeleteBudget(BudgetV budget);
        public IEnumerable<string> GetDistinctBudget();
    }
}
