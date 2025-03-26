using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefa.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas {get; set;}
    }
}