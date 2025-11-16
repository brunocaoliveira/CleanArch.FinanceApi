using FinancasPessoais.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancasPessoais.Api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<Transacao> Transacoes { get; set; }
    }
}