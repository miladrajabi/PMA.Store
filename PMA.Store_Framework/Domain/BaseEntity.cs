using System.ComponentModel.DataAnnotations;

namespace PMA.Store_Framework.Domain
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}