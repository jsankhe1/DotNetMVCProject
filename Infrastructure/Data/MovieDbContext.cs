using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }

    
    
    
    

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Favorites> Favorites { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Purchases> Purchases { get; set; }
    public DbSet<Trailer> Trailers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite Keys for junction tables
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

        modelBuilder.Entity<MovieCast>()
            .HasKey(mc => new { mc.MovieId, mc.CastId });

        modelBuilder.Entity<Favorites>()
            .HasKey(f => new { f.MovieId, f.UserId });

        modelBuilder.Entity<Reviews>()
            .HasKey(r => new { r.MovieId, r.UserId });

        modelBuilder.Entity<Purchases>()
            .HasKey(p => new { p.MovieId, p.UserId });

        modelBuilder.Entity<UserRoles>().HasKey(ur => new { ur.RoleId, ur.UserId });


        // movie prop constraints
        modelBuilder.Entity<Movie>()
            .Property(m => m.Budget)
            .HasPrecision(18, 4);

        modelBuilder.Entity<Movie>()
            .Property(m => m.Revenue)
            .HasPrecision(18, 4);

        modelBuilder.Entity<Movie>()
            .Property(m => m.Price)
            .HasPrecision(2, 2);
        
    
        

        // Configure relationships Movies

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie) // Each MovieGenre entry is related to ONE Movie
            .WithMany(m => m.MovieGenres) // ONE Movie has MANY MovieGenres
            .HasForeignKey(mg => mg.MovieId); // Foreign key linking to Movie

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        // // Configure relationships be Movie Casts
        modelBuilder.Entity<MovieCast>()
            .HasOne(mg => mg.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId);

        modelBuilder.Entity<MovieCast>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mg => mg.MovieId);
        
        
        // Configure relationships between trailers
        modelBuilder.Entity<Trailer>()
            .HasOne(t => t.Movie)
            .WithMany(m => m.Trailers)
            .HasForeignKey(t => t.MovieId);
        
        // Configure relationships between Reviews
        modelBuilder.Entity<Reviews>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId);

        modelBuilder.Entity<Reviews>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
        
        // Configure relationships between Purchases
        modelBuilder.Entity<Purchases>()
            .HasOne(pu => pu.Movie)
            .WithMany(m => m.Purchases)
            .HasForeignKey(pu => pu.MovieId);

        modelBuilder.Entity<Purchases>()
            .HasOne(pu => pu.User)
            .WithMany(us => us.Purchases)
            .HasForeignKey(pu => pu.UserId);
        
        // Configure relationships between UserRoles
        modelBuilder.Entity<UserRoles>()
            .HasOne(us => us.User)
            .WithMany(user => user.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoles>()
            .HasOne(us => us.Role)
            .WithMany(role => role.UserRolesCollection)
            .HasForeignKey(ur => ur.RoleId);


    }
}