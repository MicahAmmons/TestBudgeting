using Microsoft.AspNetCore.Mvc;

namespace TestBudgeting.Controllers
{
    public class GmailController : Controller
    {
        public IActionResult GmailPage()
        {
            return View();
        }
    }
}
