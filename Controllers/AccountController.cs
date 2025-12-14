using Microsoft.AspNetCore.Mvc;
using GiftLab.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace GiftLab.Controllers
{
    public class AccountController : Controller
    {
        // 1. Trang Đăng nhập
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            // ✅ DEMO check (sau này thay DB)
            // Ví dụ: email demo@giftlab.vn, pass 123456
            var ok = model.Email?.Trim().ToLower() == "demo@giftlab.vn"
                     && model.Password == "123456";

            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "Đăng nhập không thành công. Vui lòng kiểm tra email/mật khẩu.");
                return View(model); // ở lại trang login
            }

            // ✅ Tạo claims -> Cookie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Khách hàng demo"),
                new Claim(ClaimTypes.Email, model.Email!)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddHours(2)
                });

            // ✅ nếu có returnUrl hợp lệ thì quay lại đó
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            // ✅ mặc định vào trang tài khoản
            return RedirectToAction("Index", "User");
        }

        // 2. Trang Đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        // 3. Trang Quên mật khẩu
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Nếu địa chỉ email tồn tại, chúng tôi đã gửi hướng dẫn đặt lại mật khẩu. Vui lòng kiểm tra email của bạn.";
                return View(model);
            }
            return View(model);
        }

        // 4. Trang Đơn hàng của tôi
        [Route("account/orders")]
        public IActionResult Orders()
        {
            ViewData["Title"] = "Đơn hàng của tôi";
            return View();
        }

        // 5. Chi tiết đơn hàng
        [Route("account/orders/{id}")]
        public IActionResult OrderDetails(int id)
        {
            ViewData["Title"] = "Chi tiết đơn hàng #" + id;
            ViewData["OrderId"] = id;
            return View();
        }
    }
}
