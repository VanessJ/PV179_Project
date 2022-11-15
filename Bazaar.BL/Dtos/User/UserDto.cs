using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public ICollection<AdDto> Ads { get; set; }

        public ReviewDto ReviewerIn { get; set; }
        public ReviewDto ReviewedIn { get; set; }

    }
}
