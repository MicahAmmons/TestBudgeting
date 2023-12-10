using Microsoft.Build.Evaluation;

namespace TestBudgeting.Models.Weather
{
    public class Reminder
    {
        public int ID { get; set; }
        public string Details{ get; set; }
        public DateOnly Date { get; set; }
        public string Weekly {  get; set; }
        public int Complete { get; set; }

    }
}
