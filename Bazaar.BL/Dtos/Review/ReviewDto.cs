using Bazaar.BL.Dtos.Ad;

namespace Bazaar.BL.Dtos.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public UserDto Reviewer { get; set; }

        public Guid ReviewedId { get; set; }

        public Guid ReviewerId { get; set; }
        public UserDto Reviewed { get; set; }

        public AdDto Ad { get; set; }
        public Guid AdId { get; set; }

        public int Score { get; set; }

        public string? Descritption { get; set; }
    }
}
