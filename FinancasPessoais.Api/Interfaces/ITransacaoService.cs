using FinancasPessoais.Api.Models;
using FinancasPessoais.Api.Dtos;


namespace FinancasPessoais.Api.Interface
{
    public interface ITransacaoService
    {
        IEnumerable<Transacao>ObterTodas();

        Transacao Adicionar(CriarTransacaoDto dto);
    }
}