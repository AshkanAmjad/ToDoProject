using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Dtos;

namespace ToDo.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<List<GetItemsVM>> GetItemsAsync();
    }
}
