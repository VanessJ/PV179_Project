using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarDAL.Models
{
    public class Ad
    {
        public int AdId { get; set; }

        [MaxLength(64)]
        public string Title { get; set; }

        public DateTime TimeCreated;

        public string Description { get; set; }

        // users may pay for premium ads
        public bool IsPremium { get; set; }

        // is the offer/demand still valid
        public bool IsValid { get; set; }

        public bool isOffer { get; set; }

        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        public int UserId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<AdTag> AdTag { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }


        public Ad()
        {
            TimeCreated = DateTime.Now;
        }
    }
}
