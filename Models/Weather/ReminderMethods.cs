using Dapper;
using System.Data;
using TestBudgeting.Models.Expense;

namespace TestBudgeting.Models.Weather
{
    public class ReminderMethods
    {

        private readonly IDbConnection _conn;

        //Constructor below is to guantee that any instance passes in the connection string 
        public ReminderMethods(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Reminder> GetReminders()
        {
            string today = DateTime.Now.DayOfWeek.ToString();

            return _conn.Query<Reminder>("SELECT * FROM reminders WHERE Complete = 1 OR Weekly = @day;", new { day = today });
        }

        public void UpdateRemind(int id)
        {
            int complete = 0;
            _conn.Execute("UPDATE reminders SET Complete = @complete WHERE ID = @id",
                                      new
                                      {
                                          complete = complete,
                                          id = id,
                                      });
        }
        public void DeleteReminder(int id)
        {
            _conn.Execute("DELETE FROM reminders WHERE ID = @id;", new { id = id });
        }

        public void RefreshReminders()
        {
            DateTime currentDate = DateTime.Now;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;
            string currentDay = currentDate.DayOfWeek.ToString();
            _conn.Execute("UPDATE reminders SET Complete = 1 " +
                "WHERE (Year = @year AND Month = @month AND Day = @day) " +
                "OR (Weekly = @CurrentDay);",
                new
                {
                    year = year,
                    month = month,
                    day = day,
                    currentDay = currentDay,
                });
        }

    }
}
