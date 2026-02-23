using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo.Domain.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive {  get; set; }
        public bool IsComplete { get; set; }
    }
}
