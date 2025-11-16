using FinancasPessoais.Api.Models;

namespace FinancasPessoais.Api.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public ETipoTransacao Tipo { get; set; }
    }
}