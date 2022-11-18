using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Review;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Dtos.User
{
    public class UserProfileDetail
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public ICollection<AdListDto> Ads { get; set; }

        public IEnumerable<ReviewDto> ReviewerIn { get; set; }
        public IEnumerable<ReviewDto> ReviewedIn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
