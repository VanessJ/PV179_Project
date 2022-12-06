using Bazaar.BL.Dtos.AdTag;

namespace Bazaar.BL.Dtos.Tag
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string TagName { get; set; } = null!;

        public IEnumerable<AdTagDto> AdTags { get; set; } = null!;
    }
}
