using Going.Plaid.Entity;
using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models;
using TestBudgeting.Models.Login;

namespace TestBudgeting.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
            Login login = new Login();
            return View(login);
        }
        [HttpPost]
        public IActionResult LoginCall(Login login) 
        {
            bool success = LoginMethods.LoginAttempt(login);
            if (success == true)
            {
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("LoginPage", "Login");
            }
        }
    }
}
