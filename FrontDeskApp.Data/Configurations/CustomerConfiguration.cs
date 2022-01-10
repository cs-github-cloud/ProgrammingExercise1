using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FrontDeskApp.Core.Models;

namespace FrontDeskApp.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(m => m.CustomerId);

            builder
                .Property(m => m.CustomerId)
                .UseIdentityColumn();

            builder
                .Property(m => m.CustomerLastName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(m => m.CustomerFirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder
              .Property(m => m.CustomerPhoneNumer)
              .IsRequired()
              .HasMaxLength(100);

            builder
                .ToTable("Customer");
        }
    }
}
