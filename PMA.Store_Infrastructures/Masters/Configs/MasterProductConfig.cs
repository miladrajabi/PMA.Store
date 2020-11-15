using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Store_Domain.Masters.Entities;

namespace PMA.Store_Infrastructures.Masters.Configs
{
    public class MasterProductConfig : IEntityTypeConfiguration<MasterProduct>
    {
        public void Configure(EntityTypeBuilder<MasterProduct> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Description).IsRequired();
        }
    }
}