namespace Bazaar.BL.Dtos.User
{
    public class UserBanByUserNameDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool Banned { get; set; }
    }
}
