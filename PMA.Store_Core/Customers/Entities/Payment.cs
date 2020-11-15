using System;
using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Customers.Entities
{
    public class Payment : BaseEntity
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
