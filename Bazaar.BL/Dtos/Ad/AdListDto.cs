using Bazaar.BL.Dtos.Image;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public bool IsPremium { get; set; }

        public bool IsValid { get; set; }

        public bool IsOffer { get; set; }

        public int Price { get; set; }
        public ICollection<ImageDto> Images { get; set; } 
        public ICollection<AdDto> Tags { get; set; } 
    }
}
