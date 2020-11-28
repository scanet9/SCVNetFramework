using System;
using SCVCosmosFramework.DataLayer.DocumentModels.User;
using Microsoft.EntityFrameworkCore;

namespace SCVCosmosFramework.DataLayer
{
    public class SCVCosmosFrameworkContext : DbContext
    {
        public SCVCosmosFrameworkContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToContainer("Users")
                .HasPartitionKey(x => x.Email)
                .HasNoDiscriminator()
                .Property(x => x.Id).HasConversion<string>().ToJsonProperty("id");
        }
    }
}
