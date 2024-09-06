using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Interface;
using FluxoCaixa.Service;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTest
{
    public class SaldoDiarioServiceTests
    {
        private readonly SaldoDiarioService _service;
        private readonly Mock<ISaldoDiarioRepository> _mockSaldoDiarioRepository;
        private readonly Mock<ILogger<SaldoDiarioService>> _mockLogger;

        public SaldoDiarioServiceTests()
        {
            _mockSaldoDiarioRepository = new Mock<ISaldoDiarioRepository>();
            _mockLogger = new Mock<ILogger<SaldoDiarioService>>();
            _service = new SaldoDiarioService(_mockSaldoDiarioRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ObterSaldoDiarioPorDataAsync_DeveRetornarSaldoDiario()
        {
            // Arrange
            var data = DateTime.Now.Date;
            var saldoDiario = new SaldoDiario
            {
                Data = data,
                TotalCredito = 100.00m,
                TotalDebito = 50.00m,
                SaldoFinal = 50.00m
            };

            _mockSaldoDiarioRepository
                .Setup(repo => repo.ObterPorData(data))
                .ReturnsAsync(saldoDiario);

            // Act
            var result = await _service.ObterSaldoDiarioPorData(data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(data, result.Data);
            Assert.Equal(100.00m, result.TotalCredito);
            Assert.Equal(50.00m, result.TotalDebito);
            Assert.Equal(50.00m, result.SaldoFinal);
        }

        [Fact]
        public async Task ObterSaldoDiarioPorDataAsync_DeveRetornarNuloSeSaldoNaoExistir()
        {
            // Arrange
            var data = DateTime.Now.Date;

            _mockSaldoDiarioRepository
                .Setup(repo => repo.ObterPorData(data))
                .ReturnsAsync((SaldoDiario)null);

            // Act
            var result = await _service.ObterSaldoDiarioPorData(data);

            // Assert
            Assert.Null(result);
        }
    }
}