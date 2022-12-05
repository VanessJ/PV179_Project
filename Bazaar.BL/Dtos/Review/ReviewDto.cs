namespace Bazaar.BL.Dtos.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public UserDto Reviewer { get; set; }
        
        public UserDto Reviewed { get; set; }

        public int Score { get; set; }

        public string? Descritption { get; set; }
    }
}
