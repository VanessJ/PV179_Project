using Bazaar.BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.User
{
    public class UserFilterDto : BaseFilterDto
    {
        public string UserName { get; set; } = null!;
    }
}
