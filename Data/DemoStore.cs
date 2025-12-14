using System;
using System.Collections.Generic;
using GiftLab.Models;

//file này là file dữ liệu để demo hoi nha
namespace GiftLab.Data
{
    public static class DemoStore
    {
        public static CustomerProfile Customer => new CustomerProfile
        {
            FullName = "Trà Sữa Dâu",
            Email = "trasuadau@giftlab.vn",
            AvatarUrl = "~/images/avatar-default.png"
        };

        public static List<Order> Orders => new List<Order>
        {
            new Order {
                Code = "GL-1024",
                CreatedAt = new DateTime(2025,12,12),
                Status = "Đang giao",
                Total = 185000,
                Lines = new List<OrderLine>{
                    new OrderLine{ ProductName="Rocky Road", Qty=1, Price=35000 },
                    new OrderLine{ ProductName="Pin Cài Hoạt Hình Ghibli", Qty=1, Price=72000 },
                    new OrderLine{ ProductName="Vòng Tay Misty Forest", Qty=1, Price=34000 }
                }
            },
            new Order {
                Code = "GL-1011",
                CreatedAt = new DateTime(2025,12,05),
                Status = "Đã giao",
                Total = 340000,
                Lines = new List<OrderLine>{
                    new OrderLine{ ProductName="Box quà handmade Catput", Qty=1, Price=125000 },
                    new OrderLine{ ProductName="Túi Rút Bồ Hóng Ghibli", Qty=1, Price=65000 },
                    new OrderLine{ ProductName="Bó Hoa Mini Màu Pastel", Qty=1, Price=68000 }
                }
            },
            new Order {
                Code = "GL-0999",
                CreatedAt = new DateTime(2025,12,01),
                Status = "Đang xử lý",
                Total = 120000,
                Lines = new List<OrderLine>{
                    new OrderLine{ ProductName="Melten Lava", Qty=2, Price=25000 },
                    new OrderLine{ ProductName="Berry Puff", Qty=2, Price=35000 }
                }
            }
        };

        public static List<Address> Addresses => new List<Address>
        {
            new Address{ Title="Nhà", Detail="123 ABC, Phường X, Quận Y, TP.HCM", IsDefault=true },
            new Address{ Title="Công ty", Detail="88 XYZ, Phường Z, Quận 1, TP.HCM", IsDefault=false },
        };
    }
}
