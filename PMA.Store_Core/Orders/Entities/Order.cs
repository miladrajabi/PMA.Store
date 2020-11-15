using System;
using PMA.Store_Domain.Customers.Entities;
using PMA.Store_Framework.Domain;
using Terme.Core.Domain.Orders.Entities;

namespace PMA.Store_Domain.Orders.Entities
{
    public class Order : BaseEntity
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
