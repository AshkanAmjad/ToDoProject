using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Entities;

namespace ToDo.Data.Context
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext>options):base(options)
        {
            
        }
        public DbSet<Item> Items {  get; set; }
    }
}
