using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Models;

namespace Bazaar.DAL.Data
{
    public static class DataInitializer
    {
        //Specifying IDs is mandatory if seeding db through OnModelCreating method
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var adId = Guid.NewGuid();
            var imageId = Guid.NewGuid();
            var tagId1 = Guid.NewGuid();
            var tagId2 = Guid.NewGuid();
            var reviewId = Guid.NewGuid();
            var reactionId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData
           (
               new User
               {
                   Id = userId1,
                   UserName = "TestUser",
                   FirstName = "Jozko",
                   LastName = "Mrkvicka",
                   Email = "jozko@example.com",
                   PhoneNumber = "0000000",
               }
           );

            modelBuilder.Entity<User>().HasData
           (
               new User
               {
                   Id = userId2,
                   UserName = "Feri",
                   FirstName = "Ferko",
                   LastName = "Priezviskovy",
                   Email = "ferko@example.com",
                   PhoneNumber = "2020040444",

               }
           );

            modelBuilder.Entity<Ad>().HasData
            (
                new Ad
                {
                    Id = adId,
                    Title = "Predam macku",
                    Description = "Je velmi zlata, zbavte ma jej, prosim",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = true,
                    Price = 50,
                    UserId = userId1
                }

            );

            modelBuilder.Entity<Image>().HasData
            (
                new Image
                {
                    Id = imageId,
                    Title = "Milovana macka",
                    Url = "\\obrazokmacky.jpg",
                    AdId = adId

                }
            );

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

            modelBuilder.Entity<AdTag>().HasData
            (
                new AdTag
                {
                    Id = Guid.NewGuid(),
                    AdId = adId,
                    TagId = tagId1,
                }
            );

            modelBuilder.Entity<AdTag>().HasData
            (
                new AdTag
                {
                    Id = Guid.NewGuid(),
                    AdId = adId,
                    TagId = tagId2,
                }
            );


            modelBuilder.Entity<Reaction>().HasData
            (
                new Reaction
                {
                    Id = reactionId,
                    AdId = adId,
                    UserId = userId2,
                    Accepted = true,
                    Message = "Mam zaujem o vasu prekrasnu macku"
                }
            ) ;


            modelBuilder.Entity<Review>().HasData
            (
                new Review
                {
                    Id = reviewId,
                    ReviewerId = userId2,
                    ReviewedId = userId1,
                    Score = 5,
                    AdId = adId,
                    Descritption = "Krasna macka, 10/10 spokojnost"
                }
            );

        }
    }
}
