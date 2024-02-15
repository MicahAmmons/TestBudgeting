using Microsoft.AspNetCore.Mvc;
using TestBudgeting.Models.NTSE;

namespace TestBudgeting.Controllers
{
    public class NTSEController : Controller
    {
        private readonly NTSEMethods repo;

        public NTSEController(NTSEMethods repo)
        {
            this.repo = repo;
        }

        public IActionResult Inventory()
        {
            var ntse = repo.GetInventory();
            return View(ntse);
        }
        public IActionResult UpdateItem(NTSE item)
        {
            repo.UpdateItem(item);
            return NoContent(); // Return 204 No Content
        }
        public IActionResult InsertItem(NTSE item)
        {
            repo.InsertItem(item);
            return NoContent();
        }
    }
}
