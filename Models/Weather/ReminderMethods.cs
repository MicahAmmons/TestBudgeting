using Dapper;
using System.Data;
using System.Globalization;
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
            IEnumerable<Reminder> reminders = _conn.Query<Reminder>("SELECT * FROM reminders WHERE Complete = 1");
            //Didn't realize that I was pulling in 3 Integers for the date while I made the property DateOnly.  So I created 3 new properties
            // of INt for the day month year, then for each Reminder I am saving those into DateOnly format before passing on. 

            foreach (Reminder reminder in reminders)
            {
                if (reminder.Year.HasValue && reminder.Month.HasValue && reminder.Day.HasValue)
                {
                    reminder.Date = new DateOnly(reminder.Year.Value, reminder.Month.Value, reminder.Day.Value);
                }
                else
                {
                    reminder.Date = DateOnly.FromDateTime(DateTime.Now);
                }
            }
            return reminders;
        }

        // When checkmark is clicked, reminder set to 0 and hidden
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

        //Upon page load, all Reminders of today or where Weekly is today change to 1
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
        public void AddReminder(Reminder reminder)
        {
            if (string.IsNullOrWhiteSpace(reminder.DateAsString))
            {
                string sqlQuery = "INSERT INTO reminders (Details, Weekly) VALUES (@details, @weekly);";

                _conn.Execute(sqlQuery, new
                {
                    details = reminder.Details,
                    weekly = reminder.Weekly
                });
            }
            else
            {
                string[] dateParts = reminder.DateAsString.Split('-');
                int year = int.Parse(dateParts[0]);
                int month = int.Parse(dateParts[1]);
                int day = int.Parse(dateParts[2]);

                string sqlQuery = "INSERT INTO reminders (Details, Month, Day, Year";
                string parameters = "@details, @month, @day, @year";

                if (reminder.Weekly != null)
                {
                    sqlQuery += ", Weekly";
                    parameters += ", @weekly";
                }

                sqlQuery += ") VALUES (" + parameters + ");";

                _conn.Execute(sqlQuery, new
                {
                    details = reminder.Details,
                    month = month,
                    day = day,
                    year = year,
                    weekly = reminder.Weekly
                });
            }
        }




    }
}
