using FinancasPessoais.Api.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinancasPessoais.Api.Interface;


namespace FinancasPessoais.Api.Interface
{
    public interface ITransacaoRepository
    {
       
        Task<IEnumerable<Transacao>> GetAllAsync();
        Task<Transacao?> GetByIdAsync(Guid id);
        Task AddAsync(Transacao transacao);
        Task<bool> SaveChangesAsync();
    }
}