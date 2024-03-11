using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Core.Dtos.Helpers
{
   public class Pagination
    {
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
        public int Pages { get; set; }
        public int Total { get; set; }
    }
}
