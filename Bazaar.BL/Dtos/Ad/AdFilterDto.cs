using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.Tag;
using Optional;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdFilterDto : BaseFilterDto
    {
        public string? ContainsTitleName { get; set; }
        public string? LikeTitleName { get; set; }

        public int MinPrice { get; set; } = -1;
        public int MaxPrice { get; set; } = -1;

        public bool OnlyValid { get; set; } = false; 

        public bool OnlyOffer { get; set; } = false;

        public bool OnlyDemand { get; set; } = false;

        public string? ContainsInDescription { get; set; }
        public Guid? UserId { get; set; }
        public IEnumerable<string> TagNames { get; set; }
    }
}
