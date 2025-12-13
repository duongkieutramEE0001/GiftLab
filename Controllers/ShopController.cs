using Microsoft.AspNetCore.Mvc;
using GiftLab.Models;
using GiftLab.ViewModels; // Giả định ShopIndexViewModel và ProductDetailViewModel nằm ở đây
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftLab.Controllers
{
    // Cấu trúc ProductDetailViewModel và ProductVariant phải được định nghĩa trong GiftLab.Models hoặc GiftLab.ViewModels

    public class ShopController : Controller
    {
        // ✅ Lấy data demo dùng chung
        private List<Product> GetDemoProducts()
        {
            var all = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Rocky Road",
                    Category = "Cupcake",
                    ImagePath = "~/images/1.png", // Hình ảnh mặc định
                    ShortDescription = "Cupcake mềm mịn, phủ sốt chocolate tan chảy ✨",
                    Description = "Rocky Road Cupcake là sự kết hợp ngọt ngào giữa cốt bánh chocolate mềm ẩm, " +
                    "kem chocolate béo mịn và topping marshmallow dẻo mềm phủ chocolate drizzle thơm lừng. " +
                    "Hương vị hài hòa, không quá ngọt, vừa quen thuộc vừa đáng yêu, rất phù hợp để làm quà tặng, " +
                    "set tiệc nhỏ hoặc tự thưởng cho bản thân một chút ngọt ngào mỗi ngày. 🧁🍫",
                    Price = 35000,
                    OriginalPrice = 40000,
                    // CẬP NHẬT Variants: Thêm ID, ImagePath, OriginalPrice, và StockQuantity
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant { Id = 101, Name = "Sweet Box (4 cái)", Price = 120000, OriginalPrice = 140000, ImagePath = "~/images/1.1.png", StockQuantity = 25 },
                        new ProductVariant { Id = 102, Name = "One Sweet (1 cái)", Price = 35000, OriginalPrice = 40000, ImagePath = "~/images/1.png", StockQuantity = 20 }, 
                        new ProductVariant { Id = 103, Name = "Big Sweet Box (6 cái)", Price = 220000, OriginalPrice = null, ImagePath = "~/images/1.1.png", StockQuantity = 0 },
                    },
                    Rating = 5.0,
                    SoldCount = 210
                },
                // Các sản phẩm khác không có biến thể, ta sẽ tạo biến thể mặc định trong Action Details
                new Product { Id = 11, Name = "Melten Lava", Category = "Cookie", ImagePath = "~/images/11.png", ShortDescription = "Bánh cookie nhân lava tan chảy", Description = "Chi tiết...", Price = 25000, OriginalPrice = 35000, Rating = 5.0, SoldCount = 190 },
                new Product { Id = 28, Name = "Berry Puff", Category = "Tart", ImagePath = "~/images/28.png", ShortDescription = "Bánh tart dâu tây phồng", Description = "Chi tiết...", Price = 35000, Rating = 5.0, SoldCount = 170 },
                new Product { Id = 31, Name = "Dark Choco Truffle", Category = "Chocolate", ImagePath = "~/images/31.png", ShortDescription = "Chocolate truffle đắng nhẹ", Description = "Chi tiết...", Price = 35000, Rating = 5.0, SoldCount = 165 },
                new Product { Id = 42, Name = "Dây Đeo Điện Thoại Hình Nhân Vật Thiết Kế Theo Yêu Cầu", Category = "Đất màu", ImagePath = "~/images/42.png", ShortDescription = "Dây đeo điện thoại cá nhân hóa", Description = "Chi tiết...", Price = 52000, Rating = 4.8, SoldCount = 156 },
                new Product { Id = 47, Name = "Túi Rút Bồ Hóng Ghibli", Category = "Len mềm", ImagePath = "~/images/47.png", ShortDescription = "Túi rút len handmade hình bồ hóng", Description = "Chi tiết...", Price = 65000, OriginalPrice = 75000, Rating = 4.9, SoldCount = 142 },
                new Product { Id = 13, Name = "Rasberry Thumprint", Category = "Cookie", ImagePath = "~/images/13.png", ShortDescription = "Bánh cookie nhân mứt dâu", Description = "Chi tiết...", Price = 28000, Rating = 5.0, SoldCount = 130 },
                new Product { Id = 40, Name = "Pin Cài Hoạt Hình Ghibli", Category = "Đất màu", ImagePath = "~/images/40.png", ShortDescription = "Pin cài áo hình nhân vật Ghibli", Description = "Chi tiết...", Price = 72000, Rating = 4.9, SoldCount = 128 },
                new Product { Id = 56, Name = "Vòng Tay Misty Forest", Category = "Hạt cườm", ImagePath = "~/images/56.png", ShortDescription = "Vòng tay hạt cườm chủ đề rừng", Description = "Chi tiết...", Price = 34000, OriginalPrice = 39000, Rating = 4.9, SoldCount = 120 },
                new Product { Id = 58, Name = "Bó Hoa Mini Màu Pastel Xinh Xắn", Category = "Len mềm", ImagePath = "~/images/58.png", ShortDescription = "Bó hoa mini len móc thủ công", Description = "Chi tiết...", Price = 68000, Rating = 5.0, SoldCount = 118 }
            };

            // ✅ add thêm sản phẩm demo
            all.Add(new Product { Id = 4, Name = "Rasberry Chocolate", Category = "Cupcake", ImagePath = "~/images/4.png", ShortDescription = "Cupcake nhân socola dâu", Description = "Chi tiết...", Price = 25000, OriginalPrice = 35000, Rating = 5.0, SoldCount = 190 });
            all.Add(new Product { Id = 14, Name = "Matcha Red Bean", Category = "Cookie", ImagePath = "~/images/14.png", ShortDescription = "Cookie trà xanh nhân đậu đỏ", Description = "Chi tiết...", Price = 33000, Rating = 4.8, SoldCount = 92 });
            all.Add(new Product { Id = 25, Name = "Cherry Lychee Cream", Category = "Tart", ImagePath = "~/images/25.png", ShortDescription = "Bánh tart kem vải cherry", Description = "Chi tiết...", Price = 28000, Rating = 5.0, SoldCount = 130 });
            all.Add(new Product { Id = 34, Name = "Strawberry Cream", Category = "Chocolate", ImagePath = "~/images/34.png", ShortDescription = "Chocolate nhân kem dâu", Description = "Chi tiết...", Price = 29000, Rating = 4.8, SoldCount = 66 });
            all.Add(new Product { Id = 38, Name = "Pin Cài Chó Mèo", Category = "Đất màu", ImagePath = "~/images/38.png", ShortDescription = "Pin cài áo hình chó mèo dễ thương", Description = "Chi tiết...", Price = 85000, Rating = 4.9, SoldCount = 97 });
            all.Add(new Product { Id = 43, Name = "Pin Cài Hình Nhân Vật Thiết Kế Theo Yêu Cầu", Category = "Đất màu", ImagePath = "~/images/43.png", ShortDescription = "Pin cài áo cá nhân hóa", Description = "Chi tiết...", Price = 68000, Rating = 4.8, SoldCount = 83 });
            all.Add(new Product { Id = 49, Name = "Bồ Hóng Ghibli Dễ Thương", Category = "Len mềm", ImagePath = "~/images/49.png", ShortDescription = "Bồ hóng len móc nhỏ xinh", Description = "Chi tiết...", Price = 72000, Rating = 4.9, SoldCount = 128 });
            all.Add(new Product { Id = 50, Name = "Móc Khóa Hoa Anh Đào", Category = "Len mềm", ImagePath = "~/images/50.png", ShortDescription = "Móc khóa len móc hoa anh đào", Description = "Chi tiết...", Price = 25000, OriginalPrice = 29000, Rating = 4.9, SoldCount = 142 });
            all.Add(new Product { Id = 57, Name = "Vòng Tay Sakura Bloom", Category = "Hạt cườm", ImagePath = "~/images/57.png", ShortDescription = "Vòng tay hạt cườm hoa anh đào", Description = "Chi tiết...", Price = 34000, OriginalPrice = 39000, Rating = 4.9, SoldCount = 120 });
            all.Add(new Product { Id = 59, Name = "Box quà handmade Catput", Category = "Bộ quà", ImagePath = "~/images/59.png", ShortDescription = "Hộp quà thủ công đặc biệt", Description = "Chi tiết...", Price = 125000, Rating = 5.0, SoldCount = 118 });

            return all;
        }

        public IActionResult Index(int page = 1)
        {
            var all = GetDemoProducts();

            const int pageSize = 16; // 4x4
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

        // ✅ Trang chi tiết
        [HttpGet]
        public IActionResult Details(int id)
        {
            var all = GetDemoProducts();
            var product = all.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            // Logic: Nếu sản phẩm không có biến thể (Variants.Count = 0),
            // tạo một biến thể mặc định từ thông tin của sản phẩm chính để hiển thị.
            if (!product.Variants.Any())
            {
                product.Variants.Add(new ProductVariant
                {
                    Id = product.Id, // Dùng chính ID sản phẩm làm ID biến thể
                    Name = "Mặc định",
                    Price = product.Price,
                    OriginalPrice = product.OriginalPrice,
                    ImagePath = product.ImagePath,
                    StockQuantity = 50 // Giả định còn hàng
                });
            }

            var relatedProducts = all
                .Where(p => p.Category == product.Category && p.Id != product.Id)
                .Take(4) // Giới hạn số lượng hiển thị (ví dụ: 4 sản phẩm)
                .ToList();

            // Tạo ViewModel để truyền tất cả dữ liệu cần thiết sang View
            var viewModel = new ProductDetailViewModel
            {
                ProductInfo = product,
                ShortDescription = product.ShortDescription,
                Variants = product.Variants,
                // Breadcrumb (có thể điều chỉnh tùy theo cấu trúc website)
                Breadcrumb = $"Trang Chủ / Cửa Hàng / {product.Category}",
                // Chọn biến thể đầu tiên làm mặc định cho hiển thị ban đầu
                DefaultVariantId = product.Variants.First().Id,
                IsFavorite = false,
                RelatedProducts = relatedProducts
            };

            return View(viewModel);
        }
    }
}