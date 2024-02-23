﻿// <auto-generated />
using System;
using AppMobileBackEnd.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppMobileBackEnd.Migrations
{
    [DbContext(typeof(ApplicationMyDBContext))]
    [Migration("20240221071204_DbInit")]
    partial class DbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppMobileBackEnd.Entity.Account", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccount"));

                    b.Property<DateTime>("BirthOfDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VIP")
                        .HasColumnType("int");

                    b.HasKey("IdAccount");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbum"));

                    b.Property<string>("GenreAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAlbum")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdAlbum");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtist"));

                    b.Property<DateTime>("BirthOfDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Follower")
                        .HasColumnType("int");

                    b.Property<int>("Following")
                        .HasColumnType("int");

                    b.Property<string>("ImageArtist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameArtist")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("blueTick")
                        .HasColumnType("bit");

                    b.HasKey("IdArtist");

                    b.HasIndex("NameArtist")
                        .IsUnique();

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"));

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCategory");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.AccountFollowArtist", b =>
                {
                    b.Property<int>("IdAccountFollowArtist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccountFollowArtist"));

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("IdArtist")
                        .HasColumnType("int");

                    b.HasKey("IdAccountFollowArtist");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdArtist");

                    b.ToTable("AccountFollowArtist", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.AccountListenMusic", b =>
                {
                    b.Property<int>("IdAccountListenMusic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccountListenMusic"));

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("IdMusic")
                        .HasColumnType("int");

                    b.HasKey("IdAccountListenMusic");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdMusic");

                    b.ToTable("AccountListenMusic", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.AlbumMusic", b =>
                {
                    b.Property<int>("IdAlbumMusic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlbumMusic"));

                    b.Property<int>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<int>("IdMusic")
                        .HasColumnType("int");

                    b.HasKey("IdAlbumMusic");

                    b.HasIndex("IdAlbum");

                    b.HasIndex("IdMusic");

                    b.ToTable("AlbumMusic", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.ArtistMusic", b =>
                {
                    b.Property<int>("IdArtistMusic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtistMusic"));

                    b.Property<int>("IdArtist")
                        .HasColumnType("int");

                    b.Property<int>("IdMusic")
                        .HasColumnType("int");

                    b.HasKey("IdArtistMusic");

                    b.HasIndex("IdArtist");

                    b.HasIndex("IdMusic");

                    b.ToTable("ArtistMusic", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.CategoryMusic", b =>
                {
                    b.Property<int>("IdCategoryMusic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoryMusic"));

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdMusic")
                        .HasColumnType("int");

                    b.HasKey("IdCategoryMusic");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdMusic");

                    b.ToTable("CategoryMusic", (string)null);
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Music", b =>
                {
                    b.Property<int>("IdMusic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMusic"));

                    b.Property<string>("DataMusic")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("DesriptionMusic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageMusic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LyrcsMusic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMusic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberLike")
                        .HasColumnType("int");

                    b.HasKey("IdMusic");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.SearchHistory", b =>
                {
                    b.Property<int>("IdSearchHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSearchHistory"));

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<string>("Search")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeSearch")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSearchHistory");

                    b.HasIndex("IdAccount");

                    b.ToTable("SearchHistory");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.AccountFollowArtist", b =>
                {
                    b.HasOne("AppMobileBackEnd.Entity.Account", "Account")
                        .WithMany("accountFollowArtists")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AccountFollowArtist_Account");

                    b.HasOne("AppMobileBackEnd.Entity.Artist", "Artist")
                        .WithMany("accountFollowArtists")
                        .HasForeignKey("IdArtist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AccountFollowArtist_Artist");

                    b.Navigation("Account");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.AccountListenMusic", b =>
                {
                    b.HasOne("AppMobileBackEnd.Entity.Account", "account")
                        .WithMany("accountListenMusics")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AccountListenMusic_Account");

                    b.HasOne("AppMobileBackEnd.Entity.Music", "music")
                        .WithMany("accountListenMusics")
                        .HasForeignKey("IdMusic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AccountListenMusic_Music");

                    b.Navigation("account");

                    b.Navigation("music");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.AlbumMusic", b =>
                {
                    b.HasOne("AppMobileBackEnd.Entity.Album", "album")
                        .WithMany("albumMusics")
                        .HasForeignKey("IdAlbum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AlbumMusic_Album");

                    b.HasOne("AppMobileBackEnd.Entity.Music", "music")
                        .WithMany("albumMusics")
                        .HasForeignKey("IdMusic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AlbumMusic_Music");

                    b.Navigation("album");

                    b.Navigation("music");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.ArtistMusic", b =>
                {
                    b.HasOne("AppMobileBackEnd.Entity.Artist", "artist")
                        .WithMany("artistMusics")
                        .HasForeignKey("IdArtist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AccountListenMusic_Artist");

                    b.HasOne("AppMobileBackEnd.Entity.Music", "music")
                        .WithMany("artistMusics")
                        .HasForeignKey("IdMusic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ArtistMusic_Music");

                    b.Navigation("artist");

                    b.Navigation("music");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.EntityMoreMore.CategoryMusic", b =>
                {
                    b.HasOne("AppMobileBackEnd.Entity.Category", "category")
                        .WithMany("categoryMusics")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CategoryMusic_ACategory");

                    b.HasOne("AppMobileBackEnd.Entity.Music", "music")
                        .WithMany("categoryMusics")
                        .HasForeignKey("IdMusic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CategoryMusic_Music");

                    b.Navigation("category");

                    b.Navigation("music");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.SearchHistory", b =>
                {
                    b.HasOne("AppMobileBackEnd.Entity.Account", "account")
                        .WithMany("searchHistorys")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SearchHistory_Account");

                    b.Navigation("account");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Account", b =>
                {
                    b.Navigation("accountFollowArtists");

                    b.Navigation("accountListenMusics");

                    b.Navigation("searchHistorys");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Album", b =>
                {
                    b.Navigation("albumMusics");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Artist", b =>
                {
                    b.Navigation("accountFollowArtists");

                    b.Navigation("artistMusics");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Category", b =>
                {
                    b.Navigation("categoryMusics");
                });

            modelBuilder.Entity("AppMobileBackEnd.Entity.Music", b =>
                {
                    b.Navigation("accountListenMusics");

                    b.Navigation("albumMusics");

                    b.Navigation("artistMusics");

                    b.Navigation("categoryMusics");
                });
#pragma warning restore 612, 618
        }
    }
}