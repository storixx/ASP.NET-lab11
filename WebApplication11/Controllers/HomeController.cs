using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
