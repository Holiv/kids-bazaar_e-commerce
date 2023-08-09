using Core.Entities;

namespace KidsBazaar.DTOs
{
    public class ProductsToReturnDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string User { get; set; }
    }
}
