using Bazaar.DAL.Models;
using Bazaar.DAL.Repository;
using Bazaar.DAL.Data;


namespace Bazaar.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BazaarDBContext _dbContext;

        public IGenericRepository<Ad> AdRepository { get; }

        public IGenericRepository<Image> ImageRepository { get; }

        public IGenericRepository<Reaction> ReactionRepository { get; }

        public IGenericRepository<Review> ReviewRepository { get; }

        public IGenericRepository<Tag> TagRepository { get; }

        public IGenericRepository<User> UserRepository { get; }

        public UnitOfWork(BazaarDBContext dbContext)
        {
            _dbContext = dbContext;
            AdRepository = new GenericRepository<Ad>(_dbContext);
            ImageRepository = new GenericRepository<Image>(_dbContext);
            ReactionRepository = new GenericRepository<Reaction>(_dbContext);
            ReviewRepository = new GenericRepository<Review>(_dbContext);
            TagRepository = new GenericRepository<Tag>(_dbContext);
            UserRepository = new GenericRepository<User>(_dbContext);
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
