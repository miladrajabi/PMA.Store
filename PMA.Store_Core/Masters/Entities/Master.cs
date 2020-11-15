using System;
using PMA.Store_Domain.Photos.Entities;
using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Masters.Entities
{
    public class Master : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }
        public DateTime MembershipDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

    }
}
