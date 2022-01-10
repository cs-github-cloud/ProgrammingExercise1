using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Data.Configurations
{
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder
                .HasKey(m => m.FacilityId);

            builder
                .Property(m => m.FacilityId)
                .UseIdentityColumn();

            builder
                .Property(m => m.FacilityName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(new Facility { FacilityId = 1, FacilityName = "Facility 1" });
            builder.HasData(new Facility { FacilityId = 2, FacilityName = "Facility 2" });
            builder.HasData(new Facility { FacilityId = 3, FacilityName = "Facility 3" });

            builder
                .ToTable("Facility");
        }
    }
}
