namespace TestBudgeting.Models
{
    public interface IBudgetRepo
    {
        public double GetTotalBudgetAmount(string budget, int month);
        public IEnumerable<Budget> ViewBudgets();
        public IEnumerable<Budget> InsertBudget(Budget budgetToInsert);
        public void UpdateBudgetAmount(Budget budget);
        public Budget GetBudget(string id);
        public void DeleteBudget(Budget budget);
    }
}
