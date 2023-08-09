using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductsWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductsWithCategorySpecification(ProductSpecParams productSpec) :
            base(x =>
            (string.IsNullOrEmpty(productSpec.Search) || x.Title.ToLower().Contains(productSpec.Search)) &&
            (!productSpec.CategoryId.HasValue || x.CategoriesId == productSpec.CategoryId) &&
            (!productSpec.UserId.HasValue || x.UserId == productSpec.UserId))  
            
        {
            AddIncludes(p => p.Categories);
            AddIncludes(p => p.User);
            AddOrderBy(p => p.Title);
            ApplyPaging((productSpec.PageSize * (productSpec.PageIndex - 1)), productSpec.PageSize);

            if (!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch (productSpec.Sort)
                {
                    case "prodAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "prodDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Title);
                        break;
                }
            }
        }

        public ProductsWithCategorySpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(p => p.Categories);
            AddIncludes(p => p.User);
        }
    }
}
