
namespace Bazaar.BL.Dtos.User
{
    public class UserListDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public bool Banned { get; set; }
    }
}
