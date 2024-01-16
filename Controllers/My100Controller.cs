using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models.Home.Expense;
using TestBudgeting.Models.My100;

namespace TestBudgeting.Controllers
{
    public class My100Controller : Controller
    {

        private readonly My100Methods conn;

        public My100Controller(My100Methods conn)
        {
            this.conn = conn;
        }

        public IActionResult My100()
        {
            My100Enum my100 = new My100Enum();
            my100 = conn.ViewItems();
            return View(my100);
        }
    }
}
