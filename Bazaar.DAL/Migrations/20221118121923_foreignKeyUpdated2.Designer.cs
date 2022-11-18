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
    [Migration("20221118121923_foreignKeyUpdated2")]
    partial class foreignKeyUpdated2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdTag", b =>
                {
                    b.Property<Guid>("AdsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AdsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("AdTag");
                });

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
                            Id = new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"),
                            Description = "Je velmi zlata, zbavte ma jej, prosim",
                            IsOffer = true,
                            IsPremium = false,
                            IsValid = true,
                            Price = 50,
                            Title = "Predam macku",
                            UserId = new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc")
                        });
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
                            Id = new Guid("f6504fa4-7d18-4e40-a844-1b9ec88b6a54"),
                            AdId = new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"),
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
                            AdId = new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"),
                            UserId = new Guid("67943a2e-28de-4111-b124-e2811e84fb27"),
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
                            ReviewerId = new Guid("67943a2e-28de-4111-b124-e2811e84fb27"),
                            ReviewedId = new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descritption = "Krasna macka, 10/10 spokojnost",
                            Id = new Guid("46e2bd5a-6280-4f7e-8af4-b10e477f38b2"),
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
                            Id = new Guid("323b300f-e4de-4e29-8b33-47bb6668c78b"),
                            TagName = "Animals"
                        },
                        new
                        {
                            Id = new Guid("ec77b015-a323-4602-9170-af30de10b89d"),
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

                    b.Property<string>("LastName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc"),
                            Banned = false,
                            Email = "jozko@gmailol.com",
                            FirstName = "Jozko",
                            LastName = "Mrkvicka",
                            Level = 0,
                            PasswordHash = "tajneheslo",
                            PhoneNumber = "0000000",
                            UserName = "TestUser"
                        },
                        new
                        {
                            Id = new Guid("67943a2e-28de-4111-b124-e2811e84fb27"),
                            Banned = false,
                            Email = "ferko@gmailol.com",
                            FirstName = "Ferko",
                            LastName = "Priezviskovy",
                            Level = 0,
                            PasswordHash = "supertajneheslo",
                            PhoneNumber = "2020040444",
                            UserName = "Feri"
                        });
                });

            modelBuilder.Entity("AdTag", b =>
                {
                    b.HasOne("Bazaar.DAL.Models.Ad", null)
                        .WithMany()
                        .HasForeignKey("AdsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazaar.DAL.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
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
                    b.Navigation("Images");

                    b.Navigation("Reactions");
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