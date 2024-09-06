using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Service.Interface
{
    public interface ISaldoDiarioService
    {
        Task<SaldoDiario> ObterSaldoDiarioPorData(DateTime data);
    }
}
