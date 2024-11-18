using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        { return View(); }
    }
}
