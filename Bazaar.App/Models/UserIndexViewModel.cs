using Bazaar.BL.Dtos.User;

namespace Bazaar.App.Models
{
    public class UserIndexViewModel
    {
        public string? UserName { get; set; } = null;
        public string? Role { get; set; } = null;
        public bool? Banned { get; set; } = null;
        public IEnumerable<UserListDto>? Users { get; set; } = null;
    }
}
