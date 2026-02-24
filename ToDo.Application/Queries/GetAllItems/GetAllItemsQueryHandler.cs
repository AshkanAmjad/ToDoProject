using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs;
using ToDo.Application.Interfaces;

namespace ToDo.Application.Queries.GetAllItems
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<GetItemsDto>>
    {
        #region Props
        private readonly IItemRepository _itemRepository;
        public GetAllItemsQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        #endregion

        public async Task<List<GetItemsDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items =await _itemRepository.GetItemsAsync();
            return items;
        }
    }
}
