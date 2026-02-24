using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.Interfaces;

namespace ToDo.Application.Commands.CreateOrUpdate
{
    public class CreateOrUpdateCommandHandler:IRequestHandler<CreateOrUpdateCommand,bool>
    {
        #region Props
        private readonly IItemRepository _itemRepository;
        public CreateOrUpdateCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(CreateOrUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.CreateOrUpdateAsync(request.model);

            if (result)
               await _itemRepository.SaveChangesAsync();

            return result;
        }
        #endregion


    }
}
