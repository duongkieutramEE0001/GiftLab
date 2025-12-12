using Microsoft.AspNetCore.Mvc;
using GiftLab.Models;
using GiftLab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftLab.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            // DEMO 20 sản phẩm (sau nối DB thì thay đoạn này)
            var all = new List<Product>
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
                    SoldCount = 165
                },
                new Product
                {
                    Id = 42,
                    Name = "Dây Đeo Điện Thoại Hình Nhân Vật Thiết Kế Theo Yêu Cầu",
                    Category = "Đất màu",
                    ImagePath = "~/images/42.png",
                    Price = 52000,
                    Rating = 4.8,
                    SoldCount = 156
                },
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
                    SoldCount = 128
                },
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

            // ✅ 10 sản phẩm thêm -> PHẢI all.Add(...)
            all.Add(new Product
            {
                Id = 4,
                Name = "Rasberry Chocolate",
                Category = "Cupcake",
                ImagePath = "~/images/4.png",
                Price = 25000,
                OriginalPrice = 35000,
                Rating = 5.0,
                SoldCount = 190
            });

            all.Add(new Product
            {
                Id = 14,
                Name = "Matcha Red Bean",
                Category = "Cookie",
                ImagePath = "~/images/14.png",
                Price = 33000,
                Rating = 4.8,
                SoldCount = 92
            });

            all.Add(new Product
            {
                Id = 25, // sửa id (m đang để 13 bị trùng)
                Name = "Cherry Lychee Cream",
                Category = "Tart",
                ImagePath = "~/images/25.png",
                Price = 28000,
                Rating = 5.0,
                SoldCount = 130
            });

            all.Add(new Product
            {
                Id = 34,
                Name = "Strawberry Cream",
                Category = "Chocolate",
                ImagePath = "~/images/34.png",
                Price = 29000,
                Rating = 4.7,
                SoldCount = 66
            });

            all.Add(new Product
            {
                Id = 38,
                Name = "Pin Cài Chó Mèo",
                Category = "Đất màu",
                ImagePath = "~/images/38.png",
                Price = 85000,
                Rating = 4.9,
                SoldCount = 97
            });

            all.Add(new Product
            {
                Id = 43,
                Name = "Pin Cài Hình Nhân Vật Thiết Kế Theo Yêu Cầu",
                Category = "Đất màu",
                ImagePath = "~/images/43.png",
                Price = 68000,
                Rating = 4.8,
                SoldCount = 83
            });

            all.Add(new Product
            {
                Id = 49,
                Name = "Bồ Hóng Ghibli Dễ Thương",
                Category = "Len mềm",
                ImagePath = "~/images/49.png",
                Price = 72000,
                Rating = 4.9,
                SoldCount = 128
            });

            all.Add(new Product
            {
                Id = 50,
                Name = "Móc Khóa Hoa Anh Đào",
                Category = "Len mềm",
                ImagePath = "~/images/50.png",
                Price = 25000,
                OriginalPrice = 29000,
                Rating = 4.9,
                SoldCount = 142
            });

            all.Add(new Product
            {
                Id = 57,
                Name = "Vòng Tay Sakura Bloom",
                Category = "Hạt cườm",
                ImagePath = "~/images/57.png",
                Price = 34000,
                OriginalPrice = 39000,
                Rating = 4.9,
                SoldCount = 120
            });

            all.Add(new Product
            {
                Id = 59,
                Name = "Box quà handmade Catput",
                Category = "Bộ quà",
                ImagePath = "~/images/59.png",
                Price = 125000,
                Rating = 5.0,
                SoldCount = 118
            });

            const int pageSize = 16; // 4 hàng x 4 cột
            var total = all.Count;
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);
            page = Math.Clamp(page, 1, Math.Max(1, totalPages));

            var items = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var vm = new ShopIndexViewModel
            {
                Products = items,
                Page = page,
                TotalPages = totalPages
            };

            return View(vm);
        }
    }
}
