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


            var reviews = new List<Review>
            {
                new Review {
                    Name="Khả Hân", Stars=5,
                    Content="Bó hoa len mini quá dễ thương, cầm trên tay mới thấy tỉ mỉ và tinh tế. Hàng thủ công nhưng hoàn thiện rất đẹp. Giao nhanh, shop tư vấn nhiệt tình. Nhất định sẽ ủng hộ thêm nè 🥰"
                },
                new Review {
                    Name="Thanh Vy", Stars=5,
                    Content="Mình đặt một chiếc móc khóa đất sét ở GiftLab để tặng bạn thân, nhận hàng mà mê luôn! Món quà nhỏ nhưng được gói rất cẩn thận, chi tiết tinh tế. Cảm giác đúng kiểu “small but sweet” luôn đó 💗"
                },
                new Review {
                    Name="Minh Ngọc", Stars=5,
                    Content="Cookie của GiftLab ngon và xinh hết nấc! Mình đặt để tặng sinh nhật bạn, ai cũng khen dễ thương và ngon nữa. Giao hàng nhanh, hộp quà trang trí rất xịn 🥰"
                },
                new Review {
                    Name="Bảo Trân", Stars=5,
                    Content="Mình rất thích phong cách của GiftLab, mọi thứ đều nhẹ nhàng và dễ thương. Sản phẩm nhỏ xinh nhưng làm rất có tâm, nhìn vào là thấy liền sự tỉ mỉ. Rất phù hợp để làm quà tặng 💕"
                },
                new Review {
                    Name="Ngọc Mai", Stars=5,
                    Content="Lần đầu mua GiftLab mà ưng ghê luôn. Sản phẩm thực tế xinh hơn hình, màu sắc nhẹ nhàng và nhìn rất có hồn. Nhận quà mà thấy vui hẳn cả ngày 🥰"
                },
                new Review {
                    Name="Thu Hà", Stars=5,
                    Content="Mình đã đặt quà GiftLab vài lần rồi và lần nào cũng hài lòng. Đóng gói kỹ, giao nhanh, sản phẩm làm rất chỉnh chu. Nhìn là thấy có sự chăm chút trong từng chi tiết 💗"
                },
                new Review {
                    Name="Yến Nhi", Stars=5,
                    Content="Quà GiftLab không quá cầu kỳ nhưng rất tinh tế. Cảm giác mỗi món đều có câu chuyện riêng, cầm lên là thấy ấm áp liền. Rất hợp để tặng người mình thương ✨"
                },
                new Review {
                    Name="Phương Anh", Stars=5,
                    Content="Mình mua GiftLab để tặng sinh nhật cho chị gái, chị nhận được là cười hoài luôn. Từ hộp quà tới sản phẩm đều rất xinh và gọn gàng. Nhìn là thấy làm rất có tâm 💝"
                },
                new Review {
                    Name="Hồng Nhung", Stars=5,
                    Content="GiftLab mang lại cảm giác rất khác so với mấy shop quà tặng khác. Nhẹ nhàng, dễ thương vừa đủ và rất tinh tế. Đúng kiểu quà nhỏ nhưng làm người nhận vui liền 🫶"
                },
            };

            var vm = new HomeIndexViewModel
            {
                BestSellerProducts = bestSellers,
                Reviews = reviews
            };

            return View(vm);

        }
    }
}
