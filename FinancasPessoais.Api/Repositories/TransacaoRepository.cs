using FinancasPessoais.Api.Data;
using FinancasPessoais.Api.Interface;
using FinancasPessoais.Api.Models;

namespace FinancasPessoais.Api.Repositories
{
    public class TransacaoRepository : ITransacaoRepository{
        
        private readonly AppDbContext _context;
        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }
        public IEnumerable<Transacao> GetAll()
        {
            return _context.Transacoes.ToList();

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }       
    }
}