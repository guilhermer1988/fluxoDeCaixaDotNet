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
    }
}
