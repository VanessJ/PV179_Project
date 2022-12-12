using Bazaar.BL.Dtos.Base;

namespace Bazaar.BL.Dtos.Reaction
{
    public class ReactionFilterDto : BaseFilterDto
    {
        public Guid UserId { get; set; }
    }
}
