using System.Collections.Generic;
using PMA.Store_Domain.Photos.Entities;
using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Categories.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Children { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }
    }
}