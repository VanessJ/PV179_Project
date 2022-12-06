using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos;

namespace Bazaar.App.Models
{
    public class AdListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public bool IsPremium { get; set; }

        public bool IsValid { get; set; }

        public bool IsOffer { get; set; }

        public int Price { get; set; }
        public UserDto Creator { get; set; } = null!;

        public ICollection<ImageDto> Images { get; set; }


    }
}
