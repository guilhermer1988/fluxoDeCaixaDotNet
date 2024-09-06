using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Infra.Interface
{
    public interface ISaldoDiarioRepository : IRepository<SaldoDiario>
    {
        Task<SaldoDiario> ObterPorData(DateTime data);
        Task Adicionar(SaldoDiario saldoDiario);
        Task Atualizar(SaldoDiario saldoDiario);
    }
}
