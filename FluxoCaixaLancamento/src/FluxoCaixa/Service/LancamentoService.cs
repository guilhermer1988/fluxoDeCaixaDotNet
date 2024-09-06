using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Interface;
using FluxoCaixa.Service.Interface;

namespace FluxoCaixa.Service
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly ISaldoDiarioService _saldoDiarioService;

        public LancamentoService(ILancamentoRepository lancamentoRepository, 
            ISaldoDiarioService saldoDiarioService)
        {
            _lancamentoRepository = lancamentoRepository;
            _saldoDiarioService = saldoDiarioService;
        }

        public async Task<Lancamento> CriarLancamento(Lancamento lancamento)
        {
            if (lancamento is null)
            {
                throw new ArgumentNullException(nameof(lancamento));
            }

            using (var transaction = await _lancamentoRepository.BeginTransactionAsync())
            {
                try
                {
                    await _lancamentoRepository.Adicionar(lancamento);

                    await _saldoDiarioService.AtualizarOuCriarSaldoDiario(lancamento);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Reverte a transação em caso de erro
                    await transaction.RollbackAsync();
                }
            }
            return lancamento;
        }

        public async Task<IEnumerable<Lancamento>> ObterLancamentos()
        {
            return await _lancamentoRepository.ObterTodos();
        }

        public async Task<Lancamento> ObterLancamentoPorId(int id)
        {
            return await _lancamentoRepository.ObterPorId(id);
        }

        public async Task DeletarLancamento(int id)
        {
            var lancamento = await _lancamentoRepository.ObterPorId(id);
            if (lancamento != null)
            {
                await _lancamentoRepository.Remover(lancamento);
            }
        }
    }
}
