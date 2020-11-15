using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Store_Domain.Photos.Entities;

namespace PMA.Store_Infrastructures.Photos.Configs
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(c => c.Url).IsRequired().IsUnicode().HasMaxLength(1000);
        }
    }
}