using System;
using CosmosApiBase.DataLayer.DocumentModels.User;
using Microsoft.EntityFrameworkCore;

namespace CosmosApiBase.DataLayer
{
    public class CosmosApiBaseContext : DbContext
    {
        public CosmosApiBaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToContainer("CosmosApiBase-Users")
                .HasPartitionKey(x => x.Email)
                .HasNoDiscriminator()
                .Property(x => x.Id).HasConversion<string>().ToJsonProperty("id");
        }
    }
}
