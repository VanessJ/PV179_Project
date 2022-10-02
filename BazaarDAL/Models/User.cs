using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class User : BaseEntity
    {
        [MaxLength(64)]
        public string UserName { get; set; }

        [MaxLength(64)]
        public string? FirstName { get; set; }

        [MaxLength(64)]
        public string? LastName { get; set; }

        [MaxLength(64)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }

        public virtual ICollection<Reaction> Reactions { get; set; }

        public virtual ICollection<Review> ReviewerIn { get; set; }
        public virtual ICollection<Review> ReviewedIn { get; set; }


    }
}
