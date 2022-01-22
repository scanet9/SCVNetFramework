using Microsoft.EntityFrameworkCore;
using SqlApiBase.DataLayer.Entities;

namespace SqlApiBase.DataLayer
{
    public class SqlApiBaseContext : DbContext
    {
        public SqlApiBaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(x => x.Id);
        }
    }
}
