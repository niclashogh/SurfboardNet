using Microsoft.AspNetCore.Mvc;

namespace Rent.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
