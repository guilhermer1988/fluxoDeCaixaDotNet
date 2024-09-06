using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Domain.Request
{
    public class LancamentoRequest
    {
        public decimal Valor { get; set; }  // Valor do lançamento
        public TipoLancamento Tipo { get; set; }  // Tipo do lançamento (Débito ou Crédito)
        public string Descricao { get; set; } = string.Empty; //Observação do lançamento
    }
}
