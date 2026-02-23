using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.VMs
{
    public class CreateOrUpdateVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
    }
}
