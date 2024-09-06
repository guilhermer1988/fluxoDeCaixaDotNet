using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Data.Context;
using FluxoCaixa.Infra.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace FluxoCaixa.Infra.Repository
{
    public class LancamentoRepository : BaseRepository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Adicionar(Lancamento lancamento)
        {
            await _context.Lancamento.AddAsync(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lancamento>> ObterTodos()
        {
            return await _context.Lancamento.ToListAsync();
        }

        public async Task<Lancamento> ObterPorId(int id)
        {
            return await _context.Lancamento.FindAsync(id);
        }

        public async Task Remover(Lancamento lancamento)
        {
            _context.Lancamento.Remove(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
