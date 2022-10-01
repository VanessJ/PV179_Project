using Microsoft.EntityFrameworkCore;
using System.Linq;
using BazaarDAL.Models;
using System.Diagnostics.Contracts;

namespace BazaarDAL.Data
{
    public class BazaarDBContext : DbContext
    {
        private const string DatabaseName = "BazaarDB";
        private const string ConnectionString = $"Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database={DatabaseName};Trusted_Connection=True;";
        
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies();
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
            .HasOne<User>(r => r.User)
            .WithMany(u => u.Reactions)
            .HasForeignKey(r => r.UserId);

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
