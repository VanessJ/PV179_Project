using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Review;

namespace Bazaar.BL.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public ICollection<AdDto> Ads { get; set; }

        public IEnumerable<ReviewDto> ReviewerIn { get; set; }
        public IEnumerable<ReviewDto> ReviewedIn { get; set; }

    }
}
