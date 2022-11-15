using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdFilterDto : BaseFilterDto
    {
        public string? ContainsTitleName { get; set; }
        public string? LikeTitleName { get; set; }

        public string? ContainsInDescription { get; set; }
        public Guid? UserId { get; set; }
        public IEnumerable<string> TagNames { get; set; }
    }
}
