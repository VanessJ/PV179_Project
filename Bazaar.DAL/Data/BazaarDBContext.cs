using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bazaar.DAL.Data
{
    public class BazaarDBContext : IdentityDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Ad> Ad { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Reaction> Reaction { get; set; }
        public DbSet<Review> Review { get; set; }

        public DbSet<AdTag> AdTag { get; set; }
        public DbSet<Tag> Tag { get; set; }

        private readonly IConfigurationBuilder _configurationBuilder;

        //constructor for migrations
        public BazaarDBContext(){}
        
        //constructor for tests
        public BazaarDBContext(DbContextOptions<BazaarDBContext> options) : base(options)
        {
        }

        public BazaarDBContext(IConfigurationBuilder configurationBuilder, DbContextOptions<BazaarDBContext> options) : base(options)
        {
            _configurationBuilder = configurationBuilder;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*IConfiguration config = _configurationBuilder
                    .AddJsonFile("appsettings.json")
                    .Build();
                */
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=BazaarDB;Trusted_Connection=True;");
                base.OnConfiguring(optionsBuilder);
            }
        }

        // https://docs.microsoft.com/en-us/ef/core/modeling/
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many
            modelBuilder.Entity<User>()
                .HasMany(u => u.Ads)
                .WithOne(a => a.Creator)
                .HasForeignKey(a => a.UserId);


            modelBuilder.Entity<Reaction>()
           .HasKey(r => r.Id);

            modelBuilder.Entity<Reaction>()
            .HasOne<User>(r => r.User)
            .WithMany(u => u.Reactions)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Review>()
            .HasKey(r => r.Id);

            modelBuilder.Entity<Review>()
            .HasOne<User>(r => r.Reviewer)
            .WithMany(u => u.ReviewerIn)
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
            .HasOne<User>(r => r.Reviewed)
            .WithMany(u => u.ReviewedIn)
            .HasForeignKey(r => r.ReviewedId)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<AdTag>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tag>()
                .HasMany(a => a.AdTags)
                .WithOne(i => i.Tag)
                .HasForeignKey(a => a.TagId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Ad>()
                .HasMany(a => a.AdTags)
                .WithOne(i => i.Ad)
                .HasForeignKey(a => a.AdId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Ad>()
                .HasMany(a => a.Images)
                .WithOne(i => i.Ad)
                .HasForeignKey(a => a.AdId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ad>()
                .HasMany(a => a.Reactions)
                .WithOne(i => i.Ad)
                .HasForeignKey(a => a.AdId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ad>()
                .HasMany<Review>()
                .WithOne(i => i.Ad)
                .HasForeignKey(a => a.AdId)
                .OnDelete(DeleteBehavior.Cascade);


         

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

        }
        
    }
}
