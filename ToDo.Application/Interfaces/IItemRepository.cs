using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs;
using ToDo.Domain.Entities;

namespace ToDo.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<List<GetItemsDto>> GetItemsAsync();
        Task<bool> CreateOrUpdateAsync(CreateOrUpdateDto model);
        Task SaveChangesAsync();
        Task<Item?>GetItemByIdAsync(int? id);
        Task<bool> DeleteAsync(int id);
        Task<CreateOrUpdateDto?> GetItemByIdForUpdateAsync(int? id);


    }
}
