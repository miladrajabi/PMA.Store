using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Store_Domain.Masters.Entities;

namespace PMA.Store_Infrastructures.Masters.Configs
{
    public class MasterConfig : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.HasOne(c => c.Photo).WithOne().HasForeignKey("Photo", "PhotoId");
        }
    }
}