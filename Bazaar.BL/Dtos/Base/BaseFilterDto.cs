using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.Base
{
    public class BaseFilterDto
    {
        public int? RequestedPageNumber { get; set; }
        public int PageSize { get; set; }
        public string OderCriteria { get; set; } 
        public bool OrderAscending { get; set; }
    }
}
