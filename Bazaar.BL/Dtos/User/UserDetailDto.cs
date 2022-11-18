using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.User
{
    public class UserDetailDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public ICollection<AdListDto> Ads { get; set; }

        public IEnumerable<ReviewDto> ReviewerIn { get; set; }
        public IEnumerable<ReviewDto> ReviewedIn { get; set; }

    }
}
