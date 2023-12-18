using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TestBudgeting.Models;
using TestBudgeting.Models.Expense;
using TestBudgeting.Models.Weather;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReminderMethods repo;

        public HomeController(ReminderMethods repo)
        {
            this.repo = repo;
        }

        public IActionResult Login(string user, string password)
        {
            return View();
        }
        public IActionResult HomePage()
        {
            repo.RefreshReminders();
            Home home = WeatherMethods.GetWeather();
            home.Reminders = repo.GetReminders();
            return View(home);
        }
        public IActionResult CompleteReminder(int id)
        {
            repo.UpdateRemind(id);
            return new EmptyResult();
        }

        public IActionResult DeleteReminder(int id)
        {
            try
            {
                repo.DeleteReminder(id);
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the reminder: {ex.Message}");
            }
        }

        public IActionResult AddReminder(Reminder reminder)
        {

                repo.AddReminder(reminder);
                return new EmptyResult(); 

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}