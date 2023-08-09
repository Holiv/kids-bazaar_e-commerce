using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class CategoryByIdSpecification : BaseSpecification<Categories>
    {
        public CategoryByIdSpecification(int id) : base(c => c.Id == id)
        {
            //AddIncludes(c => c.Products);
        }
    }
}
