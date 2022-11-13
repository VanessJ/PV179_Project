using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Repository;

namespace Bazaar.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<Ad> AdRepository { get; }

        public IGenericRepository<Image> ImageRepository { get; }

        public IGenericRepository<Reaction> ReactionRepository { get; }

        public IGenericRepository<Review> ReviewRepository { get; }

        public IGenericRepository<Tag> TagRepository { get; }

        public IGenericRepository<User> UserRepository { get; }


        public Task CommitAsync();
    }
}
