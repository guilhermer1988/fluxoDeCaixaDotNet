using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoCaixa.Domain.Entities
{
    public class SaldoDiario : BaseEntity
    {
        public DateTime Data { get; set; }  // Data do saldo consolidado
        public DateTime DataAtualização { get; set; } = DateTime.UtcNow;  // Data da última atualização do saldo consolidado

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCredito { get; set; }  // Total de créditos do dia

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDebito { get; set; }  // Total de débitos do dia

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoFinal { get; set; }  // Saldo final do dia

    }
}
