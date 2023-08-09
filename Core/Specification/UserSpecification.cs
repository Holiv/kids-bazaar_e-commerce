using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification(UserSpecParams specParams) : base(u => 
            (string.IsNullOrEmpty(specParams.Search) || u.Name.ToLower().Contains(specParams.Search.ToLower())))
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            AddOrderBy(u =>  u.Name);

            if(!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "userCreated":
                        AddOrderBy(u => u.CreatedAt);
                        break;
                    case "userDesc":
                        AddOrderByDescending(u => u.Name);
                        break;
                    default:
                        AddOrderBy(u => u.Name);
                        break;
                }
            }
        }

        public UserSpecification(int id) : base(u => u.Id == id) { }

    }
}
