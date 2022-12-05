using Bazaar.BL.Services.CRUDServices;

namespace Bazaar.BL.Services.Reactions
{
    public interface IReactionService : ICRUDService
    {
        public Task AcceptReaction(Guid id);
    }
}
