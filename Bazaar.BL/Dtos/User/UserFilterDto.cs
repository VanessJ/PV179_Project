using Bazaar.BL.Dtos.Base;
using Optional;

namespace Bazaar.BL.Dtos.User
{
    public class UserFilterDto : BaseFilterDto
    {
        public Option<string> ContainsUserName { get; set; }
        public Option<string> LikeUserName { get; set; }
        public Option<string> Email { get; set; }
        public bool OnlyBanned { get; set; } = false;
        public bool OnlyNotBanned { get; set; } = false;
        public Option<int> Level { get; set; }

    }
}
