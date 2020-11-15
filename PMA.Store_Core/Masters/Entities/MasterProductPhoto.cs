using PMA.Store_Domain.Photos.Entities;
using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Masters.Entities
{
    public class MasterProductPhoto : BaseEntity
    {
        public MasterProduct MasterProducts { get; set; }
        public long MasterProductsId { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }
    }
}
