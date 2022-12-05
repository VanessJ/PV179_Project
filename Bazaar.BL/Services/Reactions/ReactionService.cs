using AutoMapper;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Services.CRUDServices;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Services.Reactions
{
    public class ReactionService : CRUDService<Reaction>, IReactionService
    {
        public ReactionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task AcceptReaction(Guid id)
        {
            var reaction = await GetByIdAsync<ReactionDto>(id);
            if (reaction == null)
            {
                throw new ArgumentException();
            }
            reaction.Accepted = true;
            await UpdateAsync<ReactionDto>(reaction);
        }
    }
}
