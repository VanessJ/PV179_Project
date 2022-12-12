using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.BL.Dtos.AdTag
{
    public class AdTagDto
    {
        public Guid Id { get; set; }
        public TagDto Tag{ get; set; }
        public AdDto Ad { get; set; }
        public Guid TagId { get; set; }
        public Guid AdId { get; set; }
    }
}
