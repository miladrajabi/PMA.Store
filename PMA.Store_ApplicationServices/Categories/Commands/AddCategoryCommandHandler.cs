using PMA.Store_Domain.Categories.Commands;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Repositories.Interface;
using PMA.Store_Domain.Masters.Commands;
using PMA.Store_Domain.Photos.Entities;
using PMA.Store_Framework.Commands;
using PMA.Store_Framework.Resources.Interface;
using PMA.Store_Resources.Resources;

namespace PMA.Store_ApplicationServices.Categories.Commands
{
    public class AddCategoryCommandHandler : CommandHandler<AddCategoryCommand>
    {
        private readonly ICategoryCommandRepository _repository;

        public AddCategoryCommandHandler(IResourceManager resourceManager, ICategoryCommandRepository repository) : base(resourceManager)
        {
            this._repository = repository;
        }

        public override CommandResult Handle(AddCategoryCommand command)
        {

            if (IsValid(command))
            {
                Category category = new Category
                {
                    Name = command.Name,
                    ParentId = command.ParentId,
                    Photo = new Photo
                    {
                        Url = command.PhotoUrl
                    }
                };
                _repository.Add(category);
                return _repository.SaveChange() > 0 ? Ok() : Failure();
            }
            return Failure();
        }

        private bool IsValid(AddCategoryCommand command)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(command.Name))
            {
                AddError(SharedResource.Required, SharedResource.CategoryName);
                isValid = false;
            }
            if (string.IsNullOrEmpty(command.PhotoUrl))
            {
                AddError(SharedResource.Required, SharedResource.CategoryName);
                isValid = false;
            }
            return isValid;
        }
    }
}