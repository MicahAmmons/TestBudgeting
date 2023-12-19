
using TestBudgeting.Models.Home.Budget;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.Home.Reminder;
using TestBudgeting.Models.Home.Time;
using TestBudgeting.Models.Home.Weather;

namespace TestBudgeting.Models.Home;


public class HomeVar
{
    public Weather1 Weather1Var { get; set; }
    public IEnumerable<Weather1> Weather1VarCollection { get; set; }
    public Weather2 Weather2Var { get; set; }
    public IEnumerable<Weather2> Weather2VarCollection { get; set; }
    public TimeV Time { get; set; }
    public IEnumerable<ReminderV> Reminders { get; set; }
    public ReminderV Reminder { get; set; }
    public ExpenseV Expense { get; set; }
    public IEnumerable<ExpenseV> ExpenseCollection { get ; set;}

    public BudgetV Budget {  get; set; }
    public IEnumerable<string> DistinctBudgets { get; set; }


    public void SetTimeV(TimeV time)
    {
        Time = time;
    }
    public void SetWeather1(Weather1 weather)
    {
        Weather1Var = weather;
    }

    public void SetWeather2(Weather2 weather)
    {
        Weather2Var = weather;
    }

    public void SetReminderV(ReminderV reminder)
    {
        Reminder = reminder;
    }

    public void SetExpenseV(ExpenseV expense)
    {
        Expense = expense;
    }

    public void SetBudgetV(BudgetV budget)
    {
        Budget = budget;
    }
}
