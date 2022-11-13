using Bazaar.BL.Dto.Ad;
using Bazaar.BL.Dto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;

        public ICollection<AdDto> Ads { get; set; }

        public ReviewDto ReviewerIn { get; set; }
        public ReviewDto ReviewedIn { get; set; }

    }
}
