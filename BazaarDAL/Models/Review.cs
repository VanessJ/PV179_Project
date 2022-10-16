using System.ComponentModel.DataAnnotations;

namespace Bazaar.DAL.Models
{
    public class Review
    {
        public int ReviewerId { get; set; }

        public virtual User Reviewer { get; set; }

        public int ReviewedId { get; set; }

        public virtual User Reviewed {get; set;}

        [Range(1, 5)]
        public int Score { get; set; }

        public string? Descritption { get; set; } 




    }
}
