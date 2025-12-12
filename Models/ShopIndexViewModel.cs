using GiftLab.Models;
using System.Collections.Generic;

namespace GiftLab.ViewModels
{
    public class ShopIndexViewModel
    {
        public IList<Product> Products { get; set; } = new List<Product>();
        public int Page { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
    }
}
