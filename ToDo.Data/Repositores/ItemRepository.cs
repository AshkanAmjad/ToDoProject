using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Context;
using ToDo.Domain.Dtos;
using ToDo.Domain.Interfaces;

namespace ToDo.Data.Repositores
{
    public class ItemRepository: IItemRepository
    {
        #region Props
        private readonly ToDoContext _context;

        public ItemRepository(ToDoContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<List<GetItemsVM>> GetItemsAsync()
            => await _context.Items
                .Select(i => new GetItemsVM
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsActive = i.IsActive ? "فعال" : "غیر فعال",
                    IsComplete = i.IsComplete ? "تکمیل" : "تکمیل نشده"
                })
                .ToListAsync();


    }
}
