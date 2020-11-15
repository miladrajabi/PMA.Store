using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Store_Domain.Masters.Entities;

namespace PMA.Store_Infrastructures.Masters.Configs
{
    public class MasterProductPhotoConfig : IEntityTypeConfiguration<MasterProductPhoto>
    {
        public void Configure(EntityTypeBuilder<MasterProductPhoto> builder)
        {
            builder.HasOne(c => c.Photo).WithMany().HasForeignKey(c => c.PhotoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}