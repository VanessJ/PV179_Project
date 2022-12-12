using System.ComponentModel.DataAnnotations;

namespace Bazaar.App.Models
{
    public class ReviewCreateViewModel
    {
        public Guid AdId { get; set; }
        public Guid ReviewerId { get; set; }

        public Guid ReviewedId { get; set; }

        public Guid ReactionId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Score { get; set; }

        public string? Descritption { get; set; }

    }
}
