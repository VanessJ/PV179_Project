namespace Bazaar.BL.Dtos.Reaction
{
    public class ReactionUpdateDto
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }

        public Guid UserId { get; set; }

        public Guid AdId { get; set; }

        public bool Accepted { get; set; }

        public bool Rejected { get; set; }

        public bool Reviewed { get; set; }
    }
}
