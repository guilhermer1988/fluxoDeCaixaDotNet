using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Interface;
using FluxoCaixa.Service.Interface;

namespace FluxoCaixa.Service
{
    public class SaldoDiarioService : ISaldoDiarioService
    {
        private readonly ISaldoDiarioRepository _saldoDiarioRepository;
        private readonly ILogger<SaldoDiarioService> _logger;

        public SaldoDiarioService(ISaldoDiarioRepository saldoDiarioRepository, ILogger<SaldoDiarioService> logger)
        {
            _saldoDiarioRepository = saldoDiarioRepository;
            _logger = logger;
        }

        public async Task<SaldoDiario> ObterSaldoDiarioPorData(DateTime data)
        {
            try
            {
                return await _saldoDiarioRepository.ObterPorData(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter saldo diário por data.");
                throw; // Propaga a exceção para o controlador
            }
        }

        public async Task AtualizarOuCriarSaldoDiario(Lancamento lancamento)
        {
            try
            {
                var saldoExistente = await _saldoDiarioRepository.ObterPorData(lancamento.Data);
                if (saldoExistente is null)
                {
                    saldoExistente = new SaldoDiario
                    {
                        Data = lancamento.Data.Date,
                        TotalCredito = lancamento.Tipo == TipoLancamento.Credito ? lancamento.Valor : 0,
                        TotalDebito = lancamento.Tipo == TipoLancamento.Debito ? lancamento.Valor : 0,
                        SaldoFinal = (lancamento.Tipo == TipoLancamento.Credito ? lancamento.Valor : -lancamento.Valor)
                    };
                    await _saldoDiarioRepository.Adicionar(saldoExistente);
                }
                else
                {
                    if (lancamento.Tipo == TipoLancamento.Credito)
                    {
                        saldoExistente.TotalCredito += lancamento.Valor;
                        saldoExistente.SaldoFinal += lancamento.Valor;
                    }
                    else
                    {
                        saldoExistente.TotalDebito += lancamento.Valor;
                        saldoExistente.SaldoFinal -= lancamento.Valor;
                    }
                    saldoExistente.DataAtualização = DateTime.UtcNow;
                    await _saldoDiarioRepository.Atualizar(saldoExistente);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar ou criar saldo diário.");
                throw; // Propaga a exceção para o controlador
            }
        }
    }
}
