using Microsoft.EntityFrameworkCore;

namespace DTN.Models
{
    public class MusicAppDbContext : DbContext
    {
        public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Artist 1" },
                new Artist { ArtistId = 2, Name = "Artist 2" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, Title = "Album 1", ReleaseDate = new DateTime(2024, 1, 1), ArtistId = 1 },
                new Album { AlbumId = 2, Title = "Album 2", ReleaseDate = new DateTime(2024, 2, 1), ArtistId = 2 }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Rock" },
                new Genre { GenreId = 2, Name = "Pop" }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, GenreId = 1 },
                new Song { SongId = 2, Title = "Song 2", ArtistId = 2, AlbumId = 2, GenreId = 2 }
            );

            // Define Relationships
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(b => b.Albums)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Forum)
                .WithMany(f => f.Posts)
                .HasForeignKey(p => p.ForumId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            // Add Indexes
            modelBuilder.Entity<Artist>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Album>().HasIndex(a => a.Title);
            modelBuilder.Entity<Song>().HasIndex(s => s.Title);
        }


    }
}
