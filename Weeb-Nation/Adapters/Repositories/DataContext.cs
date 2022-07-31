using Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Repositories
{
    public partial class DataContext : DbContext
    {

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<FavoriteSerie> FavoriteSeries { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<ToWatchSerie> ToWatchSeries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserWatchedSerie> UserWatchedSeries { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=tai.db.elephantsql.com;Port=5432;Database=ljpkgjwk;Username=ljpkgjwk;Password=hIdiF08_Ry9YrRdgiAPkccCcZBH55FG_");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.EpisodeId).HasColumnName("episodeId");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId");

                entity.HasOne(d => d.Episode)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.EpisodeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Comment_episodeId_fkey");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Comment_movieId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Comment_userId_fkey");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.ToTable("Episode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EpisodeNumber).HasColumnName("episode_number");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.SerieId).HasColumnName("serieId");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnName("sinopse");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.SerieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Episode_serieId_fkey");
            });

            modelBuilder.Entity<FavoriteSerie>(entity =>
            {
                entity.ToTable("FavoriteSerie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteSeries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FavoriteSerie_userId_fkey");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EpisodeId).HasColumnName("episodeId");

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.SerieId).HasColumnName("serieId");

                entity.HasOne(d => d.Episode)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.EpisodeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Image_episodeId_fkey");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Image_movieId_fkey");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.SerieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Image_serieId_fkey");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnName("sinopse");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FavoriteSerieId).HasColumnName("favoriteSerieId");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasColumnName("sinopse");

                entity.Property(e => e.ToWatchSerieId).HasColumnName("toWatchSerieId");

                entity.Property(e => e.UserWatchedSerieId).HasColumnName("userWatchedSerieId");

                entity.HasOne(d => d.FavoriteSerie)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.FavoriteSerieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Serie_favoriteSerieId_fkey");

                entity.HasOne(d => d.ToWatchSerie)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.ToWatchSerieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Serie_toWatchSerieId_fkey");

                entity.HasOne(d => d.UserWatchedSerie)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.UserWatchedSerieId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Serie_userWatchedSerieId_fkey");
            });

            modelBuilder.Entity<ToWatchSerie>(entity =>
            {
                entity.ToTable("ToWatchSerie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ToWatchSeries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("ToWatchSerie_userId_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "User_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "User_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            modelBuilder.Entity<UserWatchedSerie>(entity =>
            {
                entity.ToTable("UserWatchedSerie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserWatchedSeries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("UserWatchedSerie_userId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
