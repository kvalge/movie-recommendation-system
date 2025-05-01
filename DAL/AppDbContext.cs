using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DbSet<CastAndCrew> CastAndCrews { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Rating> Ratings { get; set; } = null!;
    public DbSet<RatingValue> RatingValues { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        foreach (var relationship in builder.Model
                     .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
        builder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity(j => j.ToTable("MovieGenres"));
        
        builder.Entity<Movie>()
            .HasMany(m => m.Countries)
            .WithMany(c => c.Movies)
            .UsingEntity(j => j.ToTable("MovieCountries"));
        
        builder.Entity<Movie>()
            .HasMany(m => m.CastAndCrews)
            .WithMany(c => c.Movies)
            .UsingEntity(j => j.ToTable("MovieCastAndCrews"));
        
        builder.Entity<Country>()
            .HasMany(c => c.CastAndCrews)
            .WithMany(ca => ca.Countries)
            .UsingEntity(j => j.ToTable("CountryCastAndCrews"));
        
        builder.Entity<AppUserRole>().HasIndex(a => new { a.UserId, a.RoleId }).IsUnique();

        builder.Entity<AppUserRole>()
            .HasOne(a => a.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(a => a.UserId);

        builder.Entity<AppUserRole>()
            .HasOne(a => a.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(a => a.RoleId);
    }
}