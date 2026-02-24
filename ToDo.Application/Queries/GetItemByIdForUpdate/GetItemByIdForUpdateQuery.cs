using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs;

namespace ToDo.Application.Queries.GetItemById
{
    public record GetItemByIdForUpdateQuery(int? id) : IRequest<CreateOrUpdateDto>;

}
