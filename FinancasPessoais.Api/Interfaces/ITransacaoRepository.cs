using FinancasPessoais.Api.Models;


namespace FinancasPessoais.Api.Interface
{
    public interface ITransacaoRepository
    {
        IEnumerable<Transacao>GetAll();

        void Add(Transacao transacao);

        bool SaveChanges();
    }
}