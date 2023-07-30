namespace KidsBazaar.DTOs
{
    public class ProductsForCreatingDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoriesId { get; set; }
    }
}
