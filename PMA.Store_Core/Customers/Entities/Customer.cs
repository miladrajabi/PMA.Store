using System.Collections.Generic;
using PMA.Store_Domain.Orders.Entities;
using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Customers.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public List<Order> Orders { get; set; }
        public List<Payment> Payments { get; set; }
        public List<CustomerContact> CustomerContacts { get; set; }
    }
}
