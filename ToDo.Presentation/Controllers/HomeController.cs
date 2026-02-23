using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Domain.VMs;
using ToDo.Presentation;

namespace ToDo.Presentation.Controllers
{
    public class HomeController : Controller
    {
        #region Props
        private readonly IItemRepository _itemRepository;
        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _itemRepository.GetItemsAsync();
            return View(items);
        }

        public async Task<IActionResult> CreateOrUpdateAsync(int? Id)
        {
            CreateOrUpdateVM? item = new();
            if (Id != null || Id != 0)
                item =await _itemRepository.GetItemByIdForUpdateAsync(Id);

            return View(item);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAsync(CreateOrUpdateVM model)
        { 
            try
            {
                bool result = await _itemRepository.CreateOrUpdateAsync(model);

                if (result)
                {
                    await _itemRepository.SaveChangesAsync();
                    return Redirect("/");
                }

            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return View(model);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                bool result = await _itemRepository.DeleteAsync(id);

                if (result)
                    await _itemRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

            }

            return RedirectToAction("Index");
        }

    }
}
