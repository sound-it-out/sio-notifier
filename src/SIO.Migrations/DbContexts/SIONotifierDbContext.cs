using Microsoft.EntityFrameworkCore;
using SIO.Migrations.Entities;

namespace SIO.Migrations.DbContexts
{
    public class SIONotifierDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Notification>()
                .ToTable(nameof(Notification))
                .HasKey(ps => ps.Id);

            base.OnModelCreating(builder);
        }
        public SIONotifierDbContext(DbContextOptions<SIONotifierDbContext> options) : base(options)
        {

        }

        public SIONotifierDbContext()
        {
        }
    }
}
