using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Entity.EntityMoreMore;
using Microsoft.EntityFrameworkCore;

namespace AppMobileBackEnd.DbContexts
{
    public class ApplicationMyDBContext : DbContext
    {
        public ApplicationMyDBContext(DbContextOptions options)
            : base(options) { }

        #region Dbset

        public DbSet<SearchHistory> searchHistorys { get; set; }

        public DbSet<Music> musics { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Artist> artists { get; set; }

        public DbSet<Album> albums { get; set; }

        public DbSet<Account> accounts { get; set; }
        public DbSet<CategoryMusic> categoryMusics { get; set; }

        public DbSet<AccountFollowArtist> accountFollowArtists { get; set; }

        public DbSet <AccountListenMusic> accountListenMusic { get; set; }

        public DbSet<ArtistMusic> artistMusics { get; set; }

        public DbSet<AccountRefreshToken> accountRefreshToken { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");
                entity.HasKey(a => a.IdArtist);
                entity.HasIndex(a => a.NameArtist).IsUnique(true);
                entity
                    .Property(a => a.NameArtist)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");
                entity
                    .Property(a => a.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");
                entity.HasKey(a => a.IdAccount);
                entity.HasIndex(a => a.Username).IsUnique(true);
                entity
                    .Property(a => a.NameUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");
                entity
                    .Property(a => a.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");
                entity.Property(a => a.Email).IsRequired().HasColumnType("nvarchar(255)");
            });

            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.HasKey(s => s.IdSearchHistory);
                entity
                    .HasOne(s => s.account)
                    .WithMany(s => s.searchHistorys)
                    .HasForeignKey(s => s.IdAccount)
                    .HasConstraintName("FK_SearchHistory_Account");
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.HasKey(m => m.IdMusic);
                entity
                    .Property(m => m.NameMusic)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");
                entity.Property(m => m.DataMusic).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(m => m.IdCategory);
                entity
                    .Property(m => m.NameCategory)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(m => m.IdAlbum);
                entity
                    .Property(m => m.NameAlbum)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");
            });

            modelBuilder.Entity<AccountFollowArtist>(entity =>
            {
                entity.ToTable("AccountFollowArtist");
                entity.HasKey(a => a.IdAccountFollowArtist);
                entity
                    .HasOne(a => a.Account)
                    .WithMany(a => a.accountFollowArtists)
                    .HasForeignKey(a => a.IdAccount)
                    .HasConstraintName("FK_AccountFollowArtist_Account");

                entity
                    .HasOne(a => a.Artist)
                    .WithMany(a => a.accountFollowArtists)
                    .HasForeignKey(a => a.IdArtist)
                    .HasConstraintName("FK_AccountFollowArtist_Artist");
            });

            modelBuilder.Entity<AccountListenMusic>(entity =>
            {
                entity.ToTable("AccountListenMusic");
                entity.HasKey(a => a.IdAccountListenMusic);
                entity
                    .HasOne(a => a.account)
                    .WithMany(a => a.accountListenMusics)
                    .HasForeignKey(a => a.IdAccount)
                    .HasConstraintName("FK_AccountListenMusic_Account");

                entity
                    .HasOne(a => a.music)
                    .WithMany(a => a.accountListenMusics)
                    .HasForeignKey(a => a.IdMusic)
                    .HasConstraintName("FK_AccountListenMusic_Music");
            });

            modelBuilder.Entity<ArtistMusic>(entity =>
            {
                entity.ToTable("ArtistMusic");
                entity.HasKey(a => a.IdArtistMusic);
                entity
                    .HasOne(a => a.music)
                    .WithMany(a => a.artistMusics)
                    .HasForeignKey(a => a.IdMusic)
                    .HasConstraintName("FK_ArtistMusic_Music");

                entity
                    .HasOne(a => a.artist)
                    .WithMany(a => a.artistMusics)
                    .HasForeignKey(a => a.IdArtist)
                    .HasConstraintName("FK_AccountListenMusic_Artist");
            });

            modelBuilder.Entity<AlbumMusic>(entity =>
            {
                entity.ToTable("AlbumMusic");
                entity.HasKey(a => a.IdAlbumMusic);
                entity
                    .HasOne(a => a.music)
                    .WithMany(a => a.albumMusics)
                    .HasForeignKey(a => a.IdMusic)
                    .HasConstraintName("FK_AlbumMusic_Music");

                entity
                    .HasOne(a => a.album)
                    .WithMany(a => a.albumMusics)
                    .HasForeignKey(a => a.IdAlbum)
                    .HasConstraintName("FK_AlbumMusic_Album");
            });

            modelBuilder.Entity<CategoryMusic>(entity =>
            {
                entity.ToTable("CategoryMusic");
                entity.HasKey(a => a.IdCategoryMusic);
                entity
                    .HasOne(a => a.music)
                    .WithMany(a => a.categoryMusics)
                    .HasForeignKey(a => a.IdMusic)
                    .HasConstraintName("FK_CategoryMusic_Music");

                entity
                    .HasOne(a => a.category)
                    .WithMany(a => a.categoryMusics)
                    .HasForeignKey(a => a.IdCategory)
                    .HasConstraintName("FK_CategoryMusic_ACategory");
            });
        }
    }
}
