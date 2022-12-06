using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;

namespace Bazaar.BL.Facade
{
    public interface IAdminFacade
    {
        Task AddNewTag(TagCreateDto tagCreateDto);

        Task UpdateTag(TagEditDto tagEditDto);

        Task EditTag(TagEditDto tagCreateDto);

        Task DeleteTag(Guid id);
        Task DeleteAd(Guid id);

        Task BanUser(Guid id);

        Task UnBanUser(Guid id);


        Task<IEnumerable<UserListDto>> GetBannedUsers();
    }
}
