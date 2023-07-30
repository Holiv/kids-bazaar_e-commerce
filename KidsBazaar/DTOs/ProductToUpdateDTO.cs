using Core.Entities;

namespace KidsBazaar.DTOs
{
    public class ProductToUpdateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public Categories Categories { get; set; }
    }
}
