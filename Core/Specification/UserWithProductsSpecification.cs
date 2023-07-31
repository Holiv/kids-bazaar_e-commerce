using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class UserWithProductsSpecification : BaseSpecification<User>
    {
        public UserWithProductsSpecification()
        {
            AddIncludes(u => u.Products);
        }
    }
}
