using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Interface;
using FluxoCaixa.Service;
using Moq;

namespace UnitTest
{
    public class LancamentoServiceTests
    {
        private readonly LancamentoService _service;
        private readonly Mock<ILancamentoRepository> _mockLancamentoRepository;
        private readonly Mock<ISaldoDiarioRepository> _mockSaldoDiarioRepository;
        private readonly Mock<SaldoDiarioService> _mockSaldoDiarioService;

        public LancamentoServiceTests()
        {
            _mockLancamentoRepository = new Mock<ILancamentoRepository>();
            _mockSaldoDiarioRepository = new Mock<ISaldoDiarioRepository>();
            _mockSaldoDiarioService = new Mock<SaldoDiarioService>();
            _service = new LancamentoService(_mockLancamentoRepository.Object,
                _mockSaldoDiarioService.Object);
        }

        [Fact]
        public async Task AdicionarLancamentoAsync_DeveAdicionarLancamento()
        {
            // Arrange
            var lancamento = new Lancamento
            {
                Id = 1,
                Tipo = TipoLancamento.Credito,
                Valor = 100.00m,
                Descricao = "Test",
                Data = DateTime.Now
            };

            // Act
            await _service.CriarLancamento(lancamento);

            // Assert
            _mockLancamentoRepository.Verify(repo => repo.Adicionar(lancamento), Times.Once);
        }

        [Fact]
        public async Task CriarLancamentoAsync_DeveAtualizarOuCriarSaldoDiario()
        {
            // Arrange
            var lancamento = new Lancamento
            {
                Id = 2,
                Tipo = TipoLancamento.Credito,
                Valor = 100.00m,
                Descricao = "Test",
                Data = DateTime.Now
            };

            var saldoDiario = new SaldoDiario
            {
                Data = lancamento.Data.Date,
                TotalCredito = 100.00m,
                TotalDebito = 0.00m,
                SaldoFinal = 100.00m
            };

            _mockSaldoDiarioRepository
                .Setup(repo => repo.ObterPorData(lancamento.Data.Date))
                .ReturnsAsync(saldoDiario);

            // Act
            await _service.CriarLancamento(lancamento);

            // Assert
            _mockSaldoDiarioRepository.Verify(repo => repo.Atualizar(It.IsAny<SaldoDiario>()), Times.Once);
        }

        [Fact]
        public async Task CriarLancamentoAsync_DeveCriarSaldoDiarioSeNaoExistir()
        {
            // Arrange
            var lancamento = new Lancamento
            {
                Id = 3,
                Tipo = TipoLancamento.Debito,
                Valor = 50.00m,
                Descricao = "Test",
                Data = DateTime.Now
            };

            _mockSaldoDiarioRepository
                .Setup(repo => repo.ObterPorData(lancamento.Data.Date))
                .ReturnsAsync((SaldoDiario)null);

            // Act
            await _service.CriarLancamento(lancamento);

            // Assert
            _mockSaldoDiarioRepository.Verify(repo => repo.Adicionar(It.IsAny<SaldoDiario>()), Times.Once);
        }
    }
}