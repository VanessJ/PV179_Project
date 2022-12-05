using Bazaar.BL.Dtos.Ad;

namespace Bazaar.BL.Dtos.Image
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Url { get; set; } = null!;
        public AdDto Ad { get; set; } = null!;
    }
}
