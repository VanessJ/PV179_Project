using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar.DAL.Models
{
    public class Review : BaseEntity
    {
        public Guid ReviewerId { get; set; }
        
        [ForeignKey(nameof(ReviewerId))]

        public virtual User Reviewer { get; set; }

        public Guid ReviewedId { get; set; }

        [ForeignKey(nameof(ReviewedId))]
        public virtual User Reviewed {get; set;}

        [Range(1, 5)]
        public int Score { get; set; }

        public string? Descritption { get; set; } 

        public virtual Ad Ad { get; set; }

        [ForeignKey(nameof(Ad))]
        public Guid AdId { get; set; }




    }
}
