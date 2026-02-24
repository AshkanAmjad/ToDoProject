using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Application.Commands.Delete
{
    public record DeleteCommand(int id) : IRequest<bool>;
}
