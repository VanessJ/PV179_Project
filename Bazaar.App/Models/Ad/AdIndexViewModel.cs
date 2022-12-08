using Bazaar.BL.Dtos.Ad;

namespace Bazaar.App.Models
{
    public class AdIndexViewModel
    {
        public string? LikeTitleName { get; set; }

        public int MaxPrice { get; set; } = -1;
        public int MinPrice { get; set; } = -1;
        public IEnumerable<Guid>? TagIds { get; set; }
        public bool OnlyOffer { get; set; } = false;
        public bool OnlyDemand { get; set; } = false;
        public IEnumerable<AdListDto>? Ads { get; set; }
    }
}
