using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace FluxoCaixa.Infra.Interface
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        Task Adicionar(Lancamento lancamento);
        Task<IEnumerable<Lancamento>> ObterTodos();
        Task<Lancamento> ObterPorId(int id);
        Task Remover(Lancamento lancamento);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
