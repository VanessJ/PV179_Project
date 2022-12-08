using Bazaar.BL.Dtos.Base;
using Optional;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdFilterDto : BaseFilterDto
    {
        public Option<string> ContainsTitleName { get; set; }
        public Option<string> LikeTitleName { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public bool OnlyValid { get; set; } = false; 

        public bool OnlyOffer { get; set; } = false;

        public bool OnlyDemand { get; set; } = false;

        public Option<string> ContainsInDescription { get; set; }
        public Option<Guid> UserId { get; set; }

        public Option<List<Guid>> TagIds { get; set; }
    }
}
