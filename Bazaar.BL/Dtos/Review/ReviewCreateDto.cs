namespace Bazaar.BL.Dtos.Review
{
    public class ReviewCreateDto
    {
        public Guid ReviewerId { get; set; }

        public Guid ReviewedId { get; set; }

        public Guid AdId { get; set; }

        public Guid ReactionId { get; set; }
        public int Score { get; set; }

        public string? Descritption { get; set; }
    }
}
