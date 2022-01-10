using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Data.Configurations
{
    public class StorageFacilityConfiguration : IEntityTypeConfiguration<StorageFacility>
    {
        public void Configure(EntityTypeBuilder<StorageFacility> builder)
        {
            builder
                .HasKey(m => m.StorageFacilityId);

            builder
                .Property(m => m.StorageFacilityId)
                .UseIdentityColumn();

            builder
                .Property(m => m.StorageType)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(m => m.FacilityId)
                .IsRequired();

            builder
              .Property(m => m.SlotCount)
              .IsRequired();

            builder
                .HasOne(m => m.Facility);

            builder
                .ToTable("StorageFacility");
        }
    }
}
