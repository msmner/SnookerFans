using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnookerFans.Models;

namespace SnookerFans.Infrastructure
{
    public class SnookerDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Match> Matches { get; set; } = null!;

        public DbSet<Player> Players { get; set; } = null!;

        public SnookerDbContext() : base()
        {
        }

        public SnookerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();

            modelBuilder.Entity<Player>()
            .HasIndex(p => p.UserName)
            .IsUnique();
        }
    }
}
