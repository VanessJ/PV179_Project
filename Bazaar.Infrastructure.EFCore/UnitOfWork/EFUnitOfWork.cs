using Bazaar.DAL.Models;
using Bazaar.DAL.Data;
using Bazaar.Infrastructure.UnitOfWork;
using Bazaar.Infrastructure.Repository;
using Bazaar.Infrastructure.EFCore.Repository;


namespace Bazaar.Infrastructure.EFCore.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public BazaarDBContext _bazaarDbContext;

        private IGenericRepository<Ad> adRepository;
        private IGenericRepository<Image> imageRepository;
        private IGenericRepository<Reaction> reactionRepository;
        private IGenericRepository<Review> reviewRepository;
        private IGenericRepository<Tag> tagRepository;
        private IGenericRepository<User> userRepository;

        public EFUnitOfWork(BazaarDBContext bazaarDbContext)
        {
            _bazaarDbContext = bazaarDbContext;
        }

        public IGenericRepository<Ad> AdRepository
        {
            get
            {
                if (this.adRepository == null)
                {
                    this.adRepository = new EFGenericRepository<Ad>(_bazaarDbContext);
                }
                return adRepository;
            }
        }

        public IGenericRepository<Image> ImageRepository
        {
            get
            {
                if (this.imageRepository == null)
                {
                    this.imageRepository = new EFGenericRepository<Image>(_bazaarDbContext);
                }
                return imageRepository;
            }
        }

        public IGenericRepository<Reaction> ReactionRepository
        {
            get
            {
                if (this.reactionRepository == null)
                {
                    this.reactionRepository = new EFGenericRepository<Reaction>(_bazaarDbContext);
                }
                return reactionRepository;
            }
        }

        public IGenericRepository<Review> ReviewRepository
        {
            get
            {
                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new EFGenericRepository<Review>(_bazaarDbContext);
                }
                return reviewRepository;
            }
        }

        public IGenericRepository<Tag> TagRepository
        {
            get
            {
                if (this.tagRepository == null)
                {
                    this.tagRepository = new EFGenericRepository<Tag>(_bazaarDbContext);
                }
                return tagRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new EFGenericRepository<User>(_bazaarDbContext);
                }
                return userRepository;
            }
        }

        public async Task CommitAsync()
        {
            await _bazaarDbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _bazaarDbContext.DisposeAsync();
        }
    }
}
