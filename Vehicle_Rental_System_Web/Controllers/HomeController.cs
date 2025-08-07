using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Rental_System_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Exit()
        {
            // Close the application
            Environment.Exit(0);
            return View();
        }
    }
}