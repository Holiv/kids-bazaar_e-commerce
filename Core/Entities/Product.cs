using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CreatedAt = DateTime.Now;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CategoriesId")]
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
