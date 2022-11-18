using AutoMapper;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.QueryObjects;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Bazaar.BL.Dtos;
using System.Numerics;
using Bazaar.BL.Services.Users;
using Bazaar.BL.Services.CRUDServices;

namespace Bazaar.BL.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        private readonly UserQueryObject _userQueryObject;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserQueryObject userQueryObject) : base(unitOfWork, mapper)
        {
            _userQueryObject = userQueryObject;
        }



        public async Task<IEnumerable<UserListDto>> ExecuteQueryAsync(UserFilterDto filterDto)
        {
            return await _userQueryObject.ExecuteQueryAsync(filterDto);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsOfUser(Guid id)
        {
            var user = await GetByIdAsync<UserDto>(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user.ReviewedIn;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsWrittenByUser(Guid id)
        {
            var user = await GetByIdAsync<UserDto>(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user.ReviewerIn;
        }

    }
}
