using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Dtos;
using ToDo.Domain.Entities;
using ToDo.Domain.VMs;

namespace ToDo.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<List<GetItemsVM>> GetItemsAsync();
        Task<bool> CreateOrUpdateAsync(CreateOrUpdateVM model);
        Task SaveChangesAsync();
        Task<Item?>GetItemByIdAsync(int? id);
        Task<bool> DeleteAsync(int id);
        Task<CreateOrUpdateVM?> GetItemByIdForUpdateAsync(int? id);


    }
}
