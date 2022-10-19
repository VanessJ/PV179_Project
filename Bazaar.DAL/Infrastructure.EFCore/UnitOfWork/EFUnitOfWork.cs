﻿using Bazaar.DAL.Models;
using Bazaar.DAL.Repository;
using Bazaar.DAL.Data;


namespace Bazaar.DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BazaarDBContext Context { get; } = new();

        private IGenericRepository<Ad> adRepository;
        private IGenericRepository<Image> imageRepository;
        private IGenericRepository<Reaction> reactionRepository;
        private IGenericRepository<Review> reviewRepository;
        private IGenericRepository<Tag> tagRepository;
        private IGenericRepository<User> userRepository;

        public IGenericRepository<Ad> AdRepository
        {
            get
            {
                if (this.adRepository == null)
                {
                    this.adRepository = new EFGenericRepository<Ad>(Context);
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
                    this.imageRepository = new EFGenericRepository<Image>(Context);
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
                    this.reactionRepository = new EFGenericRepository<Reaction>(Context);
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
                    this.reviewRepository = new EFGenericRepository<Review>(Context);
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
                    this.tagRepository = new EFGenericRepository<Tag>(Context);
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
                    this.userRepository = new EFGenericRepository<User>(Context);
                }
                return userRepository;
            }
        }

        public EFUnitOfWork(BazaarDBContext dbContext)
        {
            Context = dbContext;
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await Context.DisposeAsync();
        }
    }
}