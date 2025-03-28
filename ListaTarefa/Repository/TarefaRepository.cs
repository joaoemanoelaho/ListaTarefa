using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTarefa.Data;
using ListaTarefa.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefa.Repository
{
    public class TarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Método para obter todas as tarefas
        public async Task<List<Tarefa>> GetAllTarefas()
        {
            return await _context.Tarefas.ToListAsync(); // Retorna todas as tarefas do banco de dados
        }

        // Método para adicionar uma nova tarefa
        public async Task AddTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync(); // Salva no banco de dados
        }

        // Método para obter uma tarefa específica
        public async Task<Tarefa> GetTarefaById(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task AlternarConcluido(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                tarefa.Concluido = !tarefa.Concluido;
                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }

    }
}