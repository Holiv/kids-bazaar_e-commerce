using Core.Entities;

namespace KidsBazaar.DTOs
{
    public class UserToReturnDTO
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
