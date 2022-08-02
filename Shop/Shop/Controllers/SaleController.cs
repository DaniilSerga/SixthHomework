using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
