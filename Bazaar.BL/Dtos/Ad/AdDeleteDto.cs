namespace Bazaar.BL.Dtos.Ad
{
    public class AdDeleteDto
    {
        public Guid Id { get; set; }
        public bool IsValid { get; set; }
        public Guid UserId { get; set; }
    }
}
