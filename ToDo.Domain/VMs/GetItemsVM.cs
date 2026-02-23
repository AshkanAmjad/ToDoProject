using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Dtos
{
    public class GetItemsVM
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string IsActive {  get; set; }
        public string IsComplete {  get; set; }
    }
}
