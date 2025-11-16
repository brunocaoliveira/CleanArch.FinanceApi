using FinancasPessoais.Api.Data;
using FinancasPessoais.Api.Interface;
using FinancasPessoais.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Api.Repositories
{
    public class TransacaoRepository : ITransacaoRepository{
        
        private readonly AppDbContext _context;
        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transacao>> GetAllAsync()
        {
            return await _context.Transacoes.ToListAsync();

        }
        public async Task<Transacao?> GetByIdAsync(Guid id)
        {
            return await _context.Transacoes.FirstOrDefaultAsync(t=> t.Id==id);
        }

        public async Task AddAsync(Transacao transacao)
        {
            await _context.Transacoes.AddAsync(transacao);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
       

            
    }
}