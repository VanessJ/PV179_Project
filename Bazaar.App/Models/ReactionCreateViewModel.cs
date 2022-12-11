using System.ComponentModel.DataAnnotations;

namespace Bazaar.App.Models
{
    public class ReactionCreateViewModel
    {
        [Required]
        public string? Message { get; set; }

        public Guid UserId { get; set; }

        public Guid AdId { get; set; }

    }
}
