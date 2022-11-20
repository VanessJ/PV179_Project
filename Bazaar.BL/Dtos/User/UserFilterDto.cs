using Bazaar.BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optional;

namespace Bazaar.BL.Dtos.User
{
    public class UserFilterDto : BaseFilterDto
    {
        public Option<string> ContainsUserName { get; set; }
        public Option<string> LikeUserName { get; set; }

        public bool OnlyBanned { get; set; } = false;
        public bool OnlyNotBanned { get; set; } = false;

    }
}
