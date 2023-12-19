using Microsoft.Build.Evaluation;

namespace TestBudgeting.Models.Home.Reminder
{
    public class ReminderV
    {
        public int ID { get; set; }
        public string Details { get; set; }
        public DateOnly Date { get; set; }
        public string Weekly { get; set; }
        public int Complete { get; set; }
        public string DateAsString { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }



    }
}
