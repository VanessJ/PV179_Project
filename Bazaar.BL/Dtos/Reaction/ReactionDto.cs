using Bazaar.BL.Dtos.Ad;

namespace Bazaar.BL.Dtos.Reaction
{
    public class ReactionDto
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }

        public Guid UserId { get; set; }

        public Guid AdId { get; set; }
        public UserDto User { get; set; } = null!;

        public AdDto Ad { get; set; } = null!;

        public bool Accepted { get; set; }

        public bool Rejected { get; set; }

        public bool Reviewed { get; set; }
    }
}
