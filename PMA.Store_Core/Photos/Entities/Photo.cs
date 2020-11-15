using PMA.Store_Framework.Domain;

namespace PMA.Store_Domain.Photos.Entities
{
    public  class Photo : BaseEntity
    {
        public string Url { get; set; }
        public int Size { get; set; }
    }
}
