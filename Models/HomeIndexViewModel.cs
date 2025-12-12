using GiftLab.Models;
using System.Collections.Generic;

namespace GiftLab.ViewModels
{
    public class HomeIndexViewModel
    {
        public IList<Product> BestSellerProducts { get; set; } = new List<Product>();
        public List<Review> Reviews { get; set; } = new();
    }
}
