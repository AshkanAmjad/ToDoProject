using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.DTOs;

namespace ToDo.Application.Commands.CreateOrUpdate
{
    public record CreateOrUpdateCommand(CreateOrUpdateDto model) : IRequest<bool>;
}
