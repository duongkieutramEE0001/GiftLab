using System;
using System.Collections.Generic;

namespace GiftLab.Models
{
    public class Order
    {
        public string Code { get; set; } = "GL-0001";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Đang xử lý"; // Đang xử lý | Đang giao | Đã giao | Đã hủy
        public decimal Total { get; set; } = 0;

        public List<OrderLine> Lines { get; set; } = new();
    }

    public class OrderLine
    {
        public string ProductName { get; set; } = "";
        public int Qty { get; set; } = 1;
        public decimal Price { get; set; } = 0;
    }
}
