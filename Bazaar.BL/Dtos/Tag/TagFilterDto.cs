using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Base;
using Optional;

namespace Bazaar.BL.Dtos.Tag
{
    public class TagFilterDto : BaseFilterDto
    {
        public Option<string> ContainsTagName { get; set; }
        public Option<string> LikeTagName { get; set; }
    }
}
