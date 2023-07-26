using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        public User()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; }
        public List<Product> Products { get; set; }

    }
}
