using Bazaar.BL.Dtos.User;

namespace Bazaar.App.Models
{
    public class UserIndexViewModel
    {
        public IEnumerable<UserListDto> Users { get; set; }
    }
}
