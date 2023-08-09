using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class UserSpecParams
    {
        private readonly int maxPageSize = 50;
        private int pageSize = 6;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public int PageIndex { get; set; } = 1;
        private string search;
        public string Search
        {
            get => search;
            set => search = value;
        }

        public string Sort { get; set; }
    }
}
