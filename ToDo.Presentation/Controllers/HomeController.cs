using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDo.Domain.Interfaces;
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

        public async Task<IActionResult> Index()
        {
            var items =await _itemRepository.GetItemsAsync();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
