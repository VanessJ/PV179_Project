using Bazaar.BL.Dtos.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.User
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public ICollection<AdDto> Ads { get; set; }
    }
}
