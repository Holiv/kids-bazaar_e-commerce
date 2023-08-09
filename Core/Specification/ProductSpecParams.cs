using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductSpecParams
    {
        public int PageIndex { get; set; } = 1;

        private const int MaxPageSize = 50;

        private int pageSize = 6;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        
        public string Sort { get; set; }

        //Apply search operation based on the string passed as argument
        private string search;
        public string Search
        {
            get => search;
            set => search = value.ToLower();
        }


    }
}
