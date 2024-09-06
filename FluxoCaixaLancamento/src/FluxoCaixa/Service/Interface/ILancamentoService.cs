using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Service.Interface
{
    public interface ILancamentoService
    {
        Task<Lancamento> CriarLancamento(Lancamento lancamento);
        Task<IEnumerable<Lancamento>> ObterLancamentos();
        Task<Lancamento> ObterLancamentoPorId(int id);
        Task DeletarLancamento(int id);
    }
}
