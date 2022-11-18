
namespace Bazaar.BL.Dtos.User
{
    public class UserListDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Banned { get; set; }
    }
}
