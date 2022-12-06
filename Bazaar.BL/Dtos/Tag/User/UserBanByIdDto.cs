namespace Bazaar.BL.Dtos.User
{
    public class UserBanByIdDto
    {
        public Guid UserId { get; set; }
        public bool Banned { get; set; }
    }
}
