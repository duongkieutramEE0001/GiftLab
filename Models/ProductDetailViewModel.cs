using System.Collections.Generic;

namespace GiftLab.Models
{
    public class ProductDetailViewModel
    {
        // Thông tin cơ bản của sản phẩm
        public Product ProductInfo { get; set; }
        // Mô tả chi tiết (chưa có trong Product.cs nên cần thêm)
        public string ShortDescription { get; set; } = "";
        public string FullDescription { get; set; } = "";
        // Danh sách các biến thể
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        // Thông tin Breadcrumb
        public string Breadcrumb { get; set; } = ""; // Ví dụ: "Trang Chủ / Cửa Hàng / Tên Sản Phẩm"
        // Thông tin khác
        public bool IsFavorite { get; set; }
        // ID của biến thể được chọn mặc định (nếu có)
        public int DefaultVariantId { get; set; }
        public List<Product> RelatedProducts { get; set; } = new List<Product>();
    }
}