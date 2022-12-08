﻿// <auto-generated />
using System;
using Bazaar.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    [DbContext(typeof(BazaarDBContext))]
    [Migration("20221208184728_userUpdate2")]
    partial class userUpdate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bazaar.DAL.Models.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOffer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Ad");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dba16985-d949-44a7-bf12-fb681120ad52"),
                            Description = "Je velmi zlata, zbavte ma jej, prosim",
                            IsOffer = true,
                            IsPremium = false,
                            IsValid = true,
                            Price = 50,
                            Title = "Predam macku",
                            UserId = new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633")
                        });
                });

            modelBuilder.Entity("Bazaar.DAL.Models.AdTag", b =>
                {
                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TagId", "AdId");

                    b.HasIndex("AdId");

                    b.ToTable("AdTag");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d454724e-756b-43e0-8bf0-752c265f186c"),
                            AdId = new Guid("dba16985-d949-44a7-bf12-fb681120ad52"),
                            Title = "Milovana macka",
                            Url = "\\obrazokmacky.jpg"
                        });
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Reaction", b =>
                {
                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Reaction");

                    b.HasData(
                        new
                        {
                            AdId = new Guid("dba16985-d949-44a7-bf12-fb681120ad52"),
                            UserId = new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"),
                            Accepted = true,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("00000000-0000-0000-0000-000000000000"),
                            Message = "Mam zaujem o vasu prekrasnu macku"
                        });
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Review", b =>
                {
                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReviewedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descritption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("ReviewerId", "ReviewedId");

                    b.HasIndex("ReviewedId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            ReviewerId = new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"),
                            ReviewedId = new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descritption = "Krasna macka, 10/10 spokojnost",
                            Id = new Guid("c14febdd-c062-44d6-b68d-515e3f118f19"),
                            Score = 5
                        });
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4891dfce-ec77-47a4-8f24-76ee01551e93"),
                            TagName = "Animals"
                        },
                        new
                        {
                            Id = new Guid("7e666447-0571-4d21-92f5-5300ccd2cb11"),
                            TagName = "Sell"
                        });
                });

            modelBuilder.Entity("Bazaar.DAL.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Banned")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("HasPremium")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"),
                            Banned = false,
                            Email = "jozko@gmailol.com",
                            FirstName = "Jozko",
                            HasPremium = false,
                            LastName = "Mrkvicka",
                            Level = 0,
                            PhoneNumber = "0000000",
                            UserName = "TestUser"
                        },
                        new
                        {
                            Id = new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"),
                            Banned = false,
                            Email = "ferko@gmailol.com",
                            FirstName = "Ferko",
                            HasPremium = false,
                            LastName = "Priezviskovy",
                            Level = 0,
                            PhoneNumber = "2020040444",
                            UserName = "Feri"
                        });
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Ad", b =>
                {
                    b.HasOne("Bazaar.DAL.Models.User", "Creator")
                        .WithMany("Ads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.AdTag", b =>
                {
                    b.HasOne("Bazaar.DAL.Models.Ad", "Ad")
                        .WithMany("AdTags")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazaar.DAL.Models.Tag", "Tag")
                        .WithMany("AdTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Image", b =>
                {
                    b.HasOne("Bazaar.DAL.Models.Ad", "Ad")
                        .WithMany("Images")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Reaction", b =>
                {
                    b.HasOne("Bazaar.DAL.Models.Ad", "Ad")
                        .WithMany("Reactions")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazaar.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Review", b =>
                {
                    b.HasOne("Bazaar.DAL.Models.User", "Reviewed")
                        .WithMany("ReviewedIn")
                        .HasForeignKey("ReviewedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazaar.DAL.Models.User", "Reviewer")
                        .WithMany("ReviewerIn")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reviewed");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Ad", b =>
                {
                    b.Navigation("AdTags");

                    b.Navigation("Images");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.Tag", b =>
                {
                    b.Navigation("AdTags");
                });

            modelBuilder.Entity("Bazaar.DAL.Models.User", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("ReviewedIn");

                    b.Navigation("ReviewerIn");
                });
#pragma warning restore 612, 618
        }
    }
}