using Bazaar.BL.Dto.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dto.User
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public ICollection<AdDto> Ads { get; set; }
    }
}
