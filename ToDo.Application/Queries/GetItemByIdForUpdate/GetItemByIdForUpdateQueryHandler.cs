using MediatR;
using System.Runtime.InteropServices;
using ToDo.Application.DTOs;
using ToDo.Application.Interfaces;

namespace ToDo.Application.Queries.GetItemById
{
    public class GetItemByIdForUpdateQueryHandler : IRequestHandler<GetItemByIdForUpdateQuery, CreateOrUpdateDto>
    {
        #region Props
        private readonly IItemRepository _itemRepository;
        public GetItemByIdForUpdateQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        #endregion

        public async Task<CreateOrUpdateDto?> Handle(GetItemByIdForUpdateQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemByIdForUpdateAsync(request.id);

            if (item == null)
                return null;

            return item;
        }



    }
}
