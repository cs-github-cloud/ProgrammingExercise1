using Microsoft.EntityFrameworkCore;
using FrontDeskApp.Core.Models;
using FrontDeskApp.Data.Configurations;

namespace FrontDeskApp.Data
{
    public class FrontDeskAppDbContext : DbContext
    {
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<StorageFacility> StorageFacilities { get; set; }

        public FrontDeskAppDbContext(DbContextOptions<FrontDeskAppDbContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new CustomerConfiguration());

            builder
                .ApplyConfiguration(new FacilityConfiguration());

            builder
               .ApplyConfiguration(new StorageFacilityConfiguration());

            builder
              .ApplyConfiguration(new StorageConfiguration());
        }
    }
}
