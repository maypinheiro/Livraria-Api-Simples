using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public class ToDoContex:DbContext
    {
        public ToDoContex(DbContextOptions<ToDoContex>option)
            : base(option)
        {
        }

        public DbSet<Produto> TodoProducts { get; set; }
    }
}
