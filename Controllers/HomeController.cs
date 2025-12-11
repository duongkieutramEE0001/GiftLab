using Microsoft.AspNetCore.Mvc;
using GiftLab.Models;
using GiftLab.ViewModels;
using System.Collections.Generic;

namespace GiftLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // ============================
            // DỮ LIỆU DEMO – nhập thủ công
            // ============================
            var bestSellers = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Rocky Road",
                    Category = "Cupcake",
                    ImagePath = "~/images/1.png",
                    Price = 35000,
                    OriginalPrice = 40000,
                    Rating = 5.0,
                    SoldCount = 210
                },
                new Product
                {
                    Id = 11,
                    Name = "Melten Lava",
                    Category = "Cookie",
                    ImagePath = "~/images/11.png",
                    Price = 25000,
                    OriginalPrice = 35000,
                    Rating = 5.0,
                    SoldCount = 190
                },
                new Product
                {
                    Id = 28,
                    Name = "Berry Puff",
                    Category = "Tart",
                    ImagePath = "~/images/28.png",
                    Price = 35000,
                    Rating = 5.0,
                    SoldCount = 170
                },
                new Product
                {
                    Id = 31,
                    Name = "Dark Choco Truffle",
                    Category = "Chocolate",
                    ImagePath = "~/images/31.png",
                    Price = 35000,
                    Rating = 5.0,
                    SoldCount = 165 },
                new Product
                {
                    Id = 42,
                    Name = "Dây Đeo Điện Thoại Hình Nhân Vật Thiết Kế Theo Yêu Cầu",
                    Category = "Đất màu",
                    ImagePath = "~/images/42.png",
                    Price = 52000,
                    Rating = 4.8,
                    SoldCount = 156 },
                new Product
                {
                    Id = 47,
                    Name = "Túi Rút Bồ Hóng Ghibli",
                    Category = "Len mềm",
                    ImagePath = "~/images/47.png",
                    Price = 65000,
                    OriginalPrice = 75000,
                    Rating = 4.9,
                    SoldCount = 142
                },
                new Product
                {
                    Id = 13,
                    Name = "Rasberry Thumprint",
                    Category = "Cookie",
                    ImagePath = "~/images/13.png",
                    Price = 28000,
                    Rating = 5.0,
                    SoldCount = 130
                },
                new Product
                {
                    Id = 40,
                    Name = "Pin Cài Hoạt Hình Ghibli",
                    Category = "Đất màu",
                    ImagePath = "~/images/40.png",
                    Price = 72000,
                    Rating = 4.9,
                    SoldCount = 128 },
                new Product
                {
                    Id = 56,
                    Name = "Vòng Tay Misty Forest",
                    Category = "Hạt cườm",
                    ImagePath = "~/images/56.png",
                    Price = 34000,
                    OriginalPrice = 39000,
                    Rating = 4.9,
                    SoldCount = 120
                },
                new Product
                {
                    Id = 58,
                    Name = "Bó Hoa Mini Màu Pastel Xinh Xắn",
                    Category = "Len mềm",
                    ImagePath = "~/images/58.png",
                    Price = 68000,
                    Rating = 5.0,
                    SoldCount = 118
                }
            };

            var vm = new HomeIndexViewModel
            {
                BestSellerProducts = bestSellers
            };

            return View(vm);
        }
    }
}
