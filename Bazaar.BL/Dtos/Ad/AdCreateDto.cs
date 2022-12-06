using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Image;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdCreateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsPremium { get; set; }

        public bool IsValid { get; set; }

        public bool IsOffer { get; set; }

        public int Price { get; set; }

        public Guid UserId { get; set; }

        public  ICollection<ImageCreateDto> Images { get; set; }
        public ICollection<AdTagDto> AdTags { get; set; }
    }
}
