using Microsoft.EntityFrameworkCore;
using ToDo.Application.DTOs;
using ToDo.Application.Interfaces;
using ToDo.Data.Context;
using ToDo.Domain.Entities;

namespace ToDo.Data.Repositores
{
    public class ItemRepository : IItemRepository
    {
        #region Props
        private readonly ToDoContext _context;

        public ItemRepository(ToDoContext context)
        {
            _context = context;
        }


        #endregion

        public async Task<List<GetItemsDto>> GetItemsAsync()
            => await _context.Items
                .Select(i => new GetItemsDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsActive = i.IsActive,
                    IsComplete = i.IsComplete
                })
                .ToListAsync();

        public async Task<Item?> GetItemByIdAsync(int? id)
           => await _context.Items.AsNoTracking()
                                  .Where(itm => itm.Id == id)
                                  .Select(itm => new Item()
                                  {
                                      Id = itm.Id,
                                      Name = itm.Name,
                                      IsActive = itm.IsActive,
                                      IsComplete = itm.IsComplete
                                  })
                                 .FirstOrDefaultAsync();


        public async Task SaveChangesAsync()
           => _context.SaveChanges();

        public async Task<bool> CreateOrUpdateAsync(CreateOrUpdateDto model)
        {


            if (model.Id == null)
            {
                var newItem = new Item()
                {
                    IsActive = true,
                    IsComplete = false,
                    Name = model.Name,
                };
                await _context.AddAsync(newItem);
                return true;
            }
            else
            {
                var task = await GetItemByIdAsync(model.Id);

                if (task == null)
                    return false;

                task.Name = model.Name;
                task.IsActive = model.IsActive;
                task.IsComplete = model.IsComplete;

                _context.Update(task);

                return true;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetItemByIdAsync(id);

            if (item == null) return false;

            item.IsActive = false;

            _context.Items.Update(item);

            return true;

        }

        public async Task<CreateOrUpdateDto?> GetItemByIdForUpdateAsync(int? id)
         => await _context.Items.Where(itm => itm.Id == id)
                                  .Select(itm => new CreateOrUpdateDto()
                                  {
                                      Id = itm.Id,
                                      Name = itm.Name,
                                      IsActive = itm.IsActive,
                                      IsComplete = itm.IsComplete
                                  })
                                 .FirstOrDefaultAsync();
    }
}
