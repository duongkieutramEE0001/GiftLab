using Microsoft.AspNetCore.Mvc;

namespace GiftLab.Controllers
{
    public class AdminController : Controller
    {
        [Route("admin")]
        [Route("admin/index")]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Dashboard));
        }

        [Route("admin/dashboard")]
        public IActionResult Dashboard()
        {
            ViewData["Title"] = "Dashboard - Admin";
            return View();
        }

        [Route("admin/analytics")]
        public IActionResult Analytics()
        {
            ViewData["Title"] = "Analytics - Admin";
            return View();
        }

        [Route("admin/users")]
        public IActionResult Users()
        {
            ViewData["Title"] = "Users - Admin";
            return View();
        }

        [Route("admin/products")]
        public IActionResult Products()
        {
            ViewData["Title"] = "Products - Admin";
            return View();
        }

        [Route("admin/orders")]
        public IActionResult Orders()
        {
            ViewData["Title"] = "Orders - Admin";
            return View();
        }

        [Route("admin/settings")]
        public IActionResult Settings()
        {
            ViewData["Title"] = "Settings - Admin";
            return View();
        }
    }
}

