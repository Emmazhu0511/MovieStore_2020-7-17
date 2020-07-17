using System;
using MovieStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace MovieStore.Infrastructure.Data
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)

        {

           

        }



        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenres);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);


        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> modelBuilder)
        {

            //We can use Fluent API Configurations to model our tables as well
            modelBuilder.ToTable("Movie");
            modelBuilder.HasKey(m => m.Id);
            modelBuilder.Property(m => m.Title).IsRequired().HasMaxLength(256);
            modelBuilder.Property(m => m.Overview).HasMaxLength(4096);
            modelBuilder.Property(m => m.Tagline).HasMaxLength(512);
            modelBuilder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            modelBuilder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            modelBuilder.Property(m => m.PosterUrl).HasMaxLength(2084);
            modelBuilder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            modelBuilder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            modelBuilder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            modelBuilder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            // we don't want to Create Rating Column but we want C# rating property in our Entity so that we can show Movie rating in the UI
            modelBuilder.Ignore(m => m.Rating);
        }

        private void ConfigureMovieGenres(EntityTypeBuilder<MovieGenre> modelBuilder)
        {
            modelBuilder.ToTable("MovieGenre");
            modelBuilder.HasKey(mg => new { mg.GenreId, mg.MovieId });
            modelBuilder.HasOne(mg => mg.Movie).WithMany(g => g.MovieGenres).HasForeignKey(mg => mg.MovieId);
            modelBuilder.HasOne(mg => mg.Genre).WithMany(g => g.MovieGenres).HasForeignKey(mg => mg.GenreId);

        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> modelBuilder)
        {
            modelBuilder.ToTable("Trailer");
            modelBuilder.HasKey(t => t.Id);
            modelBuilder.Property(t => t.MovieId).IsRequired();
            modelBuilder.Property(t => t.Name).HasMaxLength(2084);
            modelBuilder.Property(t => t.TrailerUrl).HasMaxLength(2084);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> modelBuilder) {
            modelBuilder.ToTable("Cast");
            modelBuilder.HasKey(c=> c.Id);
            modelBuilder.Property(c=> c.Name).HasMaxLength(128);
            modelBuilder.Property(c=> c.Gender).HasMaxLength(4096);
            modelBuilder.Property(c=> c.TmdbUrl).HasMaxLength(4096);
            modelBuilder.Property(c=> c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> modelBuilder)
        {
            modelBuilder.ToTable("MovieCast");
            modelBuilder.HasKey(mc=> new { mc.CastId, mc.MovieId, mc.Character});
            modelBuilder.HasOne(mc=> mc.Cast).WithMany(c=> c.MovieCasts).HasForeignKey(mc=> mc.CastId);
            modelBuilder.HasOne(mc => mc.Movie).WithMany(m=> m.MovieCasts).HasForeignKey(mc=> mc.MovieId);
            modelBuilder.Property(mc => mc.Character).HasMaxLength(450);

        }

        private void ConfigureUser(EntityTypeBuilder<User> modelBuilder) {
            modelBuilder.ToTable("User");
            modelBuilder.HasKey(u=> u.Id);
            modelBuilder.Property(u=> u.FirstName).HasMaxLength(128);
            modelBuilder.Property(u=> u.LastName).HasMaxLength(128);
            modelBuilder.Property(u=> u.Email).HasMaxLength(256);
            modelBuilder.Property(u=> u.HashedPassword).HasMaxLength(4096);
            modelBuilder.Property(u=> u.Salt).HasMaxLength(4096);
            modelBuilder.Property(u => u.PhoneNumber).HasMaxLength(4096);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> modelBuilder) {
            modelBuilder.ToTable("Review");
            modelBuilder.HasKey(r=> new { r.UserId, r.MovieId});
            modelBuilder.HasOne(r => r.User).WithMany(r=> r.Reviews);
            modelBuilder.HasOne(r => r.Movie).WithMany(r=> r.Reviews);
            modelBuilder.Property(r => r.Rating).IsRequired().HasColumnType("decimal(3,2)");
            modelBuilder.Property(r=> r.ReviewText).HasMaxLength(4096);
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> modelBuilder)
        {
            modelBuilder.ToTable("Purchase");
            modelBuilder.HasKey(p=> p.Id);
            modelBuilder.HasIndex(p=> p.PurchaseNumber).IsUnique();
            modelBuilder.Property(p=> p.TotalPrice).HasColumnType("decimal(5,2)");
            modelBuilder.HasOne(p => p.Customer).WithMany(p=> p.Purchases);
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> modelBuilder) {

            modelBuilder.ToTable("Favorite");
            modelBuilder.HasKey(f=> f.Id);
            modelBuilder.HasOne(f => f.User).WithMany(f=> f.Favorites);
        }


        private void ConfigureRole(EntityTypeBuilder<Role> modelBuilder) {
            modelBuilder.ToTable("Role");
            modelBuilder.HasKey(r=> r.Id);
            modelBuilder.Property(r => r.Name).HasMaxLength(20);
        }


        private void ConfigureUserRole(EntityTypeBuilder<UserRole> modelBuilder) {

            modelBuilder.ToTable("UserRole");
            modelBuilder.HasKey(ur=> new { ur.UserId, ur.RoleId});
            modelBuilder.HasOne(ur=> ur.User).WithMany(ur=> ur.UserRoles);
            modelBuilder.HasOne(ur=> ur.Role).WithMany(ur=> ur.UserRoles);
        }

    }
}
