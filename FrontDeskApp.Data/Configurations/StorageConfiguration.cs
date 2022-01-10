using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Data.Configurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder
                .HasKey(m => m.StorageId);

            builder
                .Property(m => m.StorageId)
                .UseIdentityColumn();

            builder
                .HasOne(m => m.StorageFacility);

            builder
               .HasOne(m => m.Customer);

            builder
                 .Property(m => m.StorageStatus);

            builder
                .ToTable("Storage");
        }
    }
}
