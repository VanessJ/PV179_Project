namespace Bazaar.BL.Dtos.Reaction
{
    public class ReactionCreateDto
    {
        public string? Message { get; set; }

        public Guid UserId { get; set; }

        public Guid AdId { get; set; }
        public bool Accepted { get; set; } = false;
        public bool Rejected { get; set; } = false;

    }
}
