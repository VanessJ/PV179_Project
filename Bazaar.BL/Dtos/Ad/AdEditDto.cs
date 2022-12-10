using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Image;

namespace Bazaar.BL.Dtos.Ad
{
    public class AdEditDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsValid { get; set; }
        public int Price { get; set; }
        public Guid? UserId { get; set; }

    }
}
