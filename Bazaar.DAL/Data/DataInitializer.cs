﻿using Microsoft.EntityFrameworkCore;
using Bazaar.DAL.Models;

namespace Bazaar.DAL.Data
{
    public static class DataInitializer
    {
        //Specifying IDs is mandatory if seeding db through OnModelCreating method
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
           (
               new User
               {
                   Id = 1,
                   UserName = "TestUser",
                   FirstName = "Jozko",
                   LastName = "Mrkvicka",
                   Email = "jozko@gmailol.com",
                   PhoneNumber = "0000000",
                   PasswordHash = "tajneheslo"
               }
           );

            modelBuilder.Entity<User>().HasData
           (
               new User
               {
                   Id = 2,
                   UserName = "Feri",
                   FirstName = "Ferko",
                   LastName = "Priezviskovy",
                   Email = "ferko@gmailol.com",
                   PhoneNumber = "2020040444",
                   PasswordHash = "supertajneheslo"

               }
           );

            modelBuilder.Entity<Ad>().HasData
            (
                new Ad
                {
                    Id = 1,
                    Title = "Predam macku",
                    Description = "Je velmi zlata, zbavte ma jej, prosim",
                    IsOffer = true,
                    IsPremium = false,
                    IsValid = true,
                    Price = 50,
                    UserId = 1
                }

            );

            modelBuilder.Entity<Image>().HasData
            (
                new Image
                {
                    Id = 1,
                    Title = "Milovana macka",
                    Url = "\\obrazokmacky.jpg",
                    AdId = 1

                }
            );

            modelBuilder.Entity<Tag>().HasData
            (
                new Tag
                {
                    Id = 1,
                    TagName = "Animals"
                }
            );

            modelBuilder.Entity<Tag>().HasData
            (
                new Tag
                {
                    Id = 2,
                    TagName = "Sell"
                }
            );


            modelBuilder.Entity<AdTag>().HasData
            (
                new AdTag
                {
                    TagId = 1, 
                    AdId = 1
                }
            );


            modelBuilder.Entity<AdTag>().HasData
            (
                new AdTag
                {
                    TagId = 2,
                    AdId = 1
                }
            );


            modelBuilder.Entity<Reaction>().HasData
            (
                new Reaction
                {
                    AdId = 1,
                    UserId = 2,
                    Accepted = true,
                    Message = "Mam zaujem o vasu prekrasnu macku"
                }
            ) ;


            modelBuilder.Entity<Review>().HasData
            (
                new Review
                {
                    ReviewerId = 2,
                    ReviewedId = 1,
                    Score = 5,
                    Descritption = "Krasna macka, 10/10 spokojnost"
                }
            );

        }
    }
}