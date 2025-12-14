using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GiftLab.ViewModels;
using GiftLab.Data;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GiftLab.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index(string tab = "profile", string? code = null)
        {
            ViewBag.Name = User.Identity?.Name;
            ViewBag.Email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

            var orders = DemoStore.Orders;

            var vm = new AccountDashboardViewModel
            {
                ActiveTab = string.IsNullOrWhiteSpace(tab) ? "profile" : tab,
                Customer = DemoStore.Customer,
                Addresses = DemoStore.Addresses,
                Orders = orders
            };

            if (!string.IsNullOrWhiteSpace(code))
            {
                vm.ActiveTab = "orders";
                vm.ActiveOrderCode = code;
                vm.ActiveOrder = orders.FirstOrDefault(o => o.Code == code);
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
