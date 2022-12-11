using System.ComponentModel.DataAnnotations;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Models
{
    public class AdIndexViewModel
    {
        public string? LikeTitleName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int MaxPrice { get; set; }

        public string? TypeOfOrder { get; set; }
        public bool IsPremium { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int MinPrice { get; set; }
        public List<Guid>? TagIds { get; set; } = new List<Guid>();
        public string? TypeOfAd { get; set; }
        public IEnumerable<AdListDto>? Ads { get; set; }
        public IEnumerable<TagDto>? Tags { get; set; }
    }
}
