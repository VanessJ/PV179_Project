using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos;
using System.ComponentModel.DataAnnotations;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Models
{
    public class AdCreateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public string? Description { get; set; } = new string("");

        public bool IsPremium { get; set; } = false;

        public bool IsValid { get; set; } = true;

        public bool IsOffer { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }
        public UserDto Creator { get; set; } = null!;

        public List<Guid> ImageIds { get; set; }

        public IEnumerable<Guid> TagIds{ get; set; }

        public List<TagDto> AllTags { get; set; }

    }
}
