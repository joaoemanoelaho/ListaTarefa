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


        public async Task<List<Tarefa>> GetAllTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task AddTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
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

        public async Task Atualizar(int id, string descricao, DateTime dataVencimento)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                tarefa.Descricao = descricao;
                tarefa.DataVencimento = dataVencimento;
                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Deletar(int id)
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