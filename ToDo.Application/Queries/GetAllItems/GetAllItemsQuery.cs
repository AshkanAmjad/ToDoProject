using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs;

namespace ToDo.Application.Queries.GetAllItems
{
    public record GetAllItemsQuery : IRequest<List<GetItemsDto>>;
}
