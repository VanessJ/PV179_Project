using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace Bazaar.DAL.Data
{
    public class BazaarDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Ad> Ad { get; set; }
        public DbSet<AdTag> AdTag { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Reaction> Reaction { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Tag> Tag { get; set; }

        public BazaarDBContext()
        {
        }

        public BazaarDBContext(DbContextOptions<BazaarDBContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                var settings = config.GetRequiredSection(Settings.SectionName).Get<Settings>();

                optionsBuilder.UseSqlServer(settings.ConnectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        // https://docs.microsoft.com/en-us/ef/core/modeling/
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many
            modelBuilder.Entity<User>().HasMany(u => u.Ads).WithOne(a => a.Creator).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Ad>().HasMany(a => a.Images).WithOne(i => i.Ad).HasForeignKey(a => a.AdId);


            //composite keys
            modelBuilder.Entity<AdTag>()
            .HasKey(a => new { a.AdId, a.TagId });

            modelBuilder.Entity<Reaction>()
           .HasKey(r => new { r.AdId, r.UserId });

            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.ReviewerId, r.ReviewedId });


            modelBuilder.Entity<Reaction>().HasKey(r => new { r.AdId, r.UserId });

            //many to many
            modelBuilder.Entity<AdTag>()
                .HasOne<Ad>(at => at.Ad)
                .WithMany(a => a.AdTag)
                .HasForeignKey(at => at.AdId);

            modelBuilder.Entity<AdTag>()
                .HasOne<Tag>(at => at.Tag)
                .WithMany(t => t.AdTag)
                .HasForeignKey(at => at.TagId);

            modelBuilder.Entity<Reaction>()
            .HasOne<User>(r => r.User);

            modelBuilder.Entity<Reaction>()
            .HasOne<Ad>(r => r.Ad)
            .WithMany(a => a.Reactions)
            .HasForeignKey(r => r.AdId);


            modelBuilder.Entity<Review>()
            .HasOne<User>(r => r.Reviewer)
            .WithMany(u => u.ReviewerIn)
            .HasForeignKey(r => r.ReviewerId);

            modelBuilder.Entity<Review>()
            .HasOne<User>(r => r.Reviewed)
            .WithMany(u => u.ReviewedIn)
            .HasForeignKey(r => r.ReviewedId);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

        }
        
    }
}
