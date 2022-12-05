using Bazaar.BL.Dtos.Ad;

namespace Bazaar.BL.Dtos.Tag
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string TagName { get; set; } = null!;

        public IEnumerable<AdDto> Ad { get; set; } = null!;
    }
}
