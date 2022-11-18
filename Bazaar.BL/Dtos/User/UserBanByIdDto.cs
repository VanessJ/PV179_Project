using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.User
{
    public class UserBanByIdDto
    {
        public Guid UserId { get; set; }
        public bool Banned { get; set; }
    }
}
