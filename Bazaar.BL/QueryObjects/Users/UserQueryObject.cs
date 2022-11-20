using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos.User;
using AutoMapper;
using Bazaar.BL.QueryObjects.Base;

namespace Bazaar.BL.QueryObjects.Users
{
    public class UserQueryObject : BaseQueryObject<UserListDto, UserFilterDto, User, IQuery<User>>, IUserQueryObject
    {
        public UserQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query) { }

        public override IQuery<User> FilterByWhere(IQuery<User> query, UserFilterDto filter_dto)
        {
            if (!string.IsNullOrWhiteSpace(filter_dto.ContainsUserName))
            {
                query.Filter(u => u.UserName.Equals(filter_dto.ContainsUserName));
            }
            if (!string.IsNullOrWhiteSpace(filter_dto.LikeUserName))
            {
                query.Filter(u => u.UserName.Contains(filter_dto.LikeUserName));
            }

            if (filter_dto.OnlyBanned)
            {
                query.Filter(u => u.Banned);
            }

            if (!filter_dto.OnlyNotBanned)
            {
                query.Filter(u => !u.Banned);
            }

            return query;
        }
    }
}
