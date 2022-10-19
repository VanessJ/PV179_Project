﻿// <auto-generated />
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
    [Migration("20221001173638_Ad")]
    partial class Ad
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BazaarDAL.Models.Ad", b =>
                {
                    b.Property<int>("AdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isOffer")
                        .HasColumnType("bit");

                    b.HasKey("AdId");

                    b.HasIndex("UserId");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("BazaarDAL.Models.AdTag", b =>
                {
                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("AdId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AdTag");
                });

            modelBuilder.Entity("BazaarDAL.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<string>("PathToImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ImageId");

                    b.HasIndex("AdId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("BazaarDAL.Models.Reaction", b =>
                {
                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("BazaarDAL.Models.Review", b =>
                {
                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewedId")
                        .HasColumnType("int");

                    b.Property<string>("Descritption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("ReviewerId", "ReviewedId");

                    b.HasIndex("ReviewedId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("BazaarDAL.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"), 1L, 1);

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BazaarDAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

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

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "jozko@gmail.com",
                            FirstName = "Jozko",
                            LastName = "Mrkvicka",
                            PasswordHash = "tajneheslo",
                            PhoneNumber = "0000000",
                            UserName = "TestUser"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "ferko@gmail.com",
                            FirstName = "Ferko",
                            LastName = "Priezviskovy",
                            PasswordHash = "supertajneheslo",
                            PhoneNumber = "2020040444",
                            UserName = "Feri"
                        });
                });

            modelBuilder.Entity("BazaarDAL.Models.Ad", b =>
                {
                    b.HasOne("BazaarDAL.Models.User", "Creator")
                        .WithMany("Ads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("BazaarDAL.Models.AdTag", b =>
                {
                    b.HasOne("BazaarDAL.Models.Ad", "Ad")
                        .WithMany("AdTag")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaarDAL.Models.Tag", "Tag")
                        .WithMany("AdTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BazaarDAL.Models.Image", b =>
                {
                    b.HasOne("BazaarDAL.Models.Ad", "Ad")
                        .WithMany("Images")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("BazaarDAL.Models.Reaction", b =>
                {
                    b.HasOne("BazaarDAL.Models.Ad", "Ad")
                        .WithMany("Reactions")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaarDAL.Models.User", "User")
                        .WithMany("Reactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BazaarDAL.Models.Review", b =>
                {
                    b.HasOne("BazaarDAL.Models.User", "Reviewed")
                        .WithMany("ReviewedIn")
                        .HasForeignKey("ReviewedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazaarDAL.Models.User", "Reviewer")
                        .WithMany("ReviewerIn")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reviewed");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("BazaarDAL.Models.Ad", b =>
                {
                    b.Navigation("AdTag");

                    b.Navigation("Images");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("BazaarDAL.Models.Tag", b =>
                {
                    b.Navigation("AdTag");
                });

            modelBuilder.Entity("BazaarDAL.Models.User", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("Reactions");

                    b.Navigation("ReviewedIn");

                    b.Navigation("ReviewerIn");
                });
#pragma warning restore 612, 618
        }
    }
}