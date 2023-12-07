using Microsoft.AspNetCore.Mvc;

namespace TestBudgeting.Controllers
{
    public class Gmail : Controller
    {
        public IActionResult GmailPage()
        {
            return View();
        }
    }
}
