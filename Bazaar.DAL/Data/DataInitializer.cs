using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Models;

namespace Bazaar.DAL.Data
{
    public static class DataInitializer
    {
        //Specifying IDs is mandatory if seeding db through OnModelCreating method
        public static void Seed(this ModelBuilder modelBuilder)
        {
            
            var tagId1 = Guid.NewGuid();
            var tagId2 = Guid.NewGuid();

            modelBuilder.Entity<Tag>().HasData
            (
                new Tag
                {
                    Id = tagId1,
                    TagName = "Animals"
                }
            );

            modelBuilder.Entity<Tag>().HasData
            (
                new Tag
                {
                    Id = tagId2,
                    TagName = "Sell"
                }
            );

        }
    }
}
