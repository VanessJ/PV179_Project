using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;

namespace Bazaar.BL.Facade
{
    public interface IAdminFacade
    {
        Task AddNewTag(TagCreateDto tagCreateDto);

        Task EditTag(TagEditDto tagCreateDto);

        Task DeleteTag(Guid id);

        Task BanUserById(Guid id);

        Task BanUserByUserName(string userName);

        Task UnBanUserById(Guid id);

        Task UnBanUserByUserName(string userName);

        Task<IEnumerable<UserListDto>> GetBannedUsers();
    }
}
