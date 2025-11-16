using FinancasPessoais.Api.Models;
using FinancasPessoais.Api.Dtos;


namespace FinancasPessoais.Api.Interface
{
    public interface ITransacaoService
    {
        Task<IEnumerable<Transacao>> ObterTodasAsync();
        Task<Transacao> AdicionarAsync(CriarTransacaoDto dto);
        Task<Transacao?> ObterPorIdAsync(Guid id);
    }
}