namespace GiftLab.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Category { get; set; } = "";

        public string ImagePath { get; set; } = "";
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }

        public double Rating { get; set; }
        public int SoldCount { get; set; }     // dùng để tính sp bán chạy

        public bool IsOnSale =>
            OriginalPrice.HasValue && OriginalPrice > Price;
        public string? ShortDescription { get; set; }
        public List<string> Variants { get; set; } = new();
    }
}
