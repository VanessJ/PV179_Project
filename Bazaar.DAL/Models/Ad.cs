using System.ComponentModel.DataAnnotations;

namespace Bazaar.DAL.Models
{
    public class Ad : BaseEntity
    {
        [MaxLength(255)]
        public string Title { get; set; }


        public string Description { get; set; }

        // users may pay for premium ads
        public bool IsPremium { get; set; }

        // is the offer/demand still valid
        public bool IsValid { get; set; }

        // ad may be offer or demand 
        public bool IsOffer { get; set; }

        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        public Guid UserId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<AdTag> AdTag { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }


    }
}
