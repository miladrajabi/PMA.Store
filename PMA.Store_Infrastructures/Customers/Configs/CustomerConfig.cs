using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Store_Domain.Customers.Entities;

namespace PMA.Store_Infrastructures.Customers.Configs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(150).IsRequired();
            builder.Property(c => c.NationalCode).HasMaxLength(10).IsRequired();
        }
    }
}