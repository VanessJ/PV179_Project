using System.ComponentModel.DataAnnotations;

namespace Bazaar.DAL.Models
{
    public class User : BaseEntity
    {
        [MaxLength(64)]
        public string UserName { get; set; }

        public bool Banned { get; set; }

        [MaxLength(64)]
        public string? FirstName { get; set; }

        [MaxLength(64)]
        public string? LastName { get; set; }

        [MaxLength(64)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public string Roles { get; set; } = "User";

        public virtual ICollection<Ad> Ads { get; set; }

        public virtual ICollection<Review> ReviewerIn { get; set; }
        public virtual ICollection<Review> ReviewedIn { get; set; }


    }
}
