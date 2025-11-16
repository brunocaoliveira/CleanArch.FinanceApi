
using FinancasPessoais.Api.Models; 
namespace FinancasPessoais.Api.Dtos{
    public class CriarTransacaoDto
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public ETipoTransacao Tipo { get; set; }
    }
}