using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Review;

namespace Bazaar.BL.Dtos.User
{
    public class UserProfileDetailDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public IEnumerable<AdListDto> Ads { get; set; }

        public IEnumerable<ReviewDto> ReviewerIn { get; set; }
        public IEnumerable<ReviewDto> ReviewedIn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public int Level { get; set; }
        public bool Banned { get; set; }
        public string PhoneNumber { get; set; }
    }
}
