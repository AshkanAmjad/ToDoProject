using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.Interfaces;

namespace ToDo.Application.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        #region Props
        private readonly IItemRepository _itemRepository;
        public DeleteCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }       
        #endregion

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.DeleteAsync(request.id);

            if (result)
                await _itemRepository.SaveChangesAsync();

            return result;
        }
    }
}
