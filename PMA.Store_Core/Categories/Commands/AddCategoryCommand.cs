using PMA.Store_Framework.Commands;

namespace PMA.Store_Domain.Categories.Commands
{
    public class AddCategoryCommand : ICommand
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string PhotoUrl { get; set; }
        public int PhotoSize { get; set; }
    }
}