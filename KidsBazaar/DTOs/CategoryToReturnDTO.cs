namespace KidsBazaar.DTOs
{
    public class CategoryToReturnDTO
    {
        public string Name { get; set; }
        public ICollection<ProductsToReturnDTO> Products { get; set; }
    }
}
