using AutoMapper;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.User;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Bazaar.BL.Dtos;
using Bazaar.BL.Services.Users;
using Bazaar.BL.Services.CRUDServices;
using Bazaar.BL.QueryObjects.Users;
using Optional;

namespace Bazaar.BL.Services
{
    public class UserService : CRUDService<User>, IUserService
    {
        private readonly IUserQueryObject _userQueryObject;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserQueryObject userQueryObject) : base(unitOfWork, mapper)
        {
            _userQueryObject = userQueryObject;
        }

        public async Task<bool> IsPremium(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                throw new ArgumentException();
            }

            return user.HasPremium;
        }

        public async Task<IEnumerable<UserListDto>> ExecuteQueryAsync(UserFilterDto filterDto)
        {
            return await _userQueryObject.ExecuteQueryAsync(filterDto);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsOfUser(Guid id)
        {
            var user = await GetByIdAsync<UserDto>(id, nameof(User.ReviewedIn));
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user.ReviewedIn;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsWrittenByUser(Guid id)
        {
            var user = await GetByIdAsync<UserDto>(id, nameof(User.ReviewerIn));
            if (user == null)
            {
                throw new ArgumentException();
            }
            return user.ReviewerIn;
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            var users = await ExecuteQueryAsync(new UserFilterDto { ContainsUserName = username.Some() });
            return (users == null);
        }

        public async Task SetAsPremium(Guid id)
        {
            var user = await GetByIdAsync<UserEditDto>(id);
            if (user == null)
            {
                throw new ArgumentException();
            }
            user.HasPremium = true;
            await UpdateAsync<UserEditDto>(user);
        }
    }
}
