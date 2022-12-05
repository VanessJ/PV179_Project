using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsPremium { get; set; }

        public bool IsValid { get; set; }

        public bool IsOffer { get; set; }

        public int Price { get; set; }
        public  UserDto Creator { get; set; } = null!;

        public ICollection<ImageDto> Images { get; set; }

        public ICollection<TagDto> Tags { get; set; }
        public ICollection<ReactionDto> Reactions { get; set; }
    }
}
