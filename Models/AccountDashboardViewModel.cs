using System.Collections.Generic;
using GiftLab.Models;

namespace GiftLab.ViewModels
{
    public class AccountDashboardViewModel
    {
        // profile
        public CustomerProfile Customer { get; set; } = new();
        public List<Address> Addresses { get; set; } = new();

        // orders
        public List<Order> Orders { get; set; } = new();

        // tab: profile | orders | password
        public string ActiveTab { get; set; } = "profile";

        // xem chi tiết đơn demo (optional)
        public string? ActiveOrderCode { get; set; }
        public Order? ActiveOrder { get; set; }
    }
}
