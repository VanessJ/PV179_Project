using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Base;

namespace Bazaar.BL.Dtos.Tag
{
    public class TagFilterDto : BaseFilterDto
    {
        public string? ContainsTagName { get; set; }
        public string? LikeTagName { get; set; }
    }
}
