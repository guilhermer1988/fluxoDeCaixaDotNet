using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoCaixa.Domain.Entities
{
    public class Lancamento : BaseEntity
    {

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }  // Valor do lançamento

        public TipoLancamento Tipo { get; set; }  // Tipo do lançamento (Débito ou Crédito)

        public DateTime Data { get; set; } = DateTime.UtcNow; // Data do lançamento
        public string Descricao { get; set; } = string.Empty; //Observação do lançamento

    }

    // Enum para definir os tipos de lançamento
    public enum TipoLancamento
    {
        Credito,  // Representa um crédito
        Debito    // Representa um débito
    }
}
