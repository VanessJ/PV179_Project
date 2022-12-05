using Bazaar.BL.Dtos.User;
using Bazaar.BL.QueryObjects.Base;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;

namespace Bazaar.BL.QueryObjects.Users
{
    public interface IUserQueryObject : IBaseQueryObject<UserListDto, UserFilterDto, User, IQuery<User>>
    {
        IQuery<User> FilterByWhere(IQuery<User> query, UserFilterDto filter_dto);
    }
}
