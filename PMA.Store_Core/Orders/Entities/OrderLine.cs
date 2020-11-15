using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Orders.Entities
{
    public class OrderLine : BaseEntity
    {
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public long MasterProductsId { get; set; }
        public MasterProduct MasterProduct { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
    }
}
