using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Application.DTOs
{
    public class GetItemsDto
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public bool IsActive {  get; set; }
        public bool IsComplete {  get; set; }
    }
}
