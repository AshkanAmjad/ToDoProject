using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateOrUpdate;
using ToDo.Application.Commands.Delete;
using ToDo.Application.DTOs;
using ToDo.Application.Interfaces;
using ToDo.Application.Queries.GetAllItems;
using ToDo.Application.Queries.GetItemById;

namespace ToDo.Presentation.Controllers
{
    public class HomeController : Controller
    {
        #region Props
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;
        public HomeController(IItemRepository itemRepository,IMediator mediator)
        {
            _itemRepository = itemRepository;
            _mediator = mediator;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _mediator.Send(new GetAllItemsQuery());
            return View(items);
        }

        public async Task<IActionResult> CreateOrUpdateAsync(int? id)
        {
            CreateOrUpdateDto? item = new();
            if (id != null || id != 0)
                item =await _mediator.Send(new GetItemByIdForUpdateQuery(id));

            return View(item);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAsync(CreateOrUpdateDto model)
        { 
            try
            {
                bool result = await _mediator.Send(new CreateOrUpdateCommand(model));

                if (result)
                { 
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
                bool result =await _mediator.Send(new DeleteCommand(id));
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
