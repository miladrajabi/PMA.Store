using System;
using PMA.Store_Domain.Masters.Commands;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Masters.Repositories.Interface;
using PMA.Store_Domain.Photos.Entities;
using PMA.Store_Framework.Commands;
using PMA.Store_Framework.Resources.Interface;
using PMA.Store_Resources.Resources;

namespace PMA.Store_ApplicationServices.Masters.Commands
{
    public class AddMasterCommandHandler : CommandHandler<AddMasterCommand>
    {

        private readonly IMasterCommandRepository _commandRepository;

        public AddMasterCommandHandler(IResourceManager resourceManager, IMasterCommandRepository commandRepository) : base(resourceManager)
        {
            _commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddMasterCommand command)
        {
            if (!IsValid(command)) return Failure();
            var master = new Master
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Description = command.Description,
                ShortDescription = command.ShortDescription,
                MembershipDate = DateTime.Now,
                Photo = new Photo
                {
                    Url = command.PhotoUrl
                }
            };
            _commandRepository.Add(master);
            return _commandRepository.SaveChange() > 0 ? Ok() : Failure();
        }
        private bool IsValid(AddMasterCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.FirstName))
            {
                AddError(SharedResource.Required, SharedResource.FirstName);
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