
using FinancasPessoais.Api.Models;
using FinancasPessoais.Api.Dtos;
using FinancasPessoais.Api.Interface;

namespace FinancasPessoais.Api.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _repository;
        public TransacaoService(ITransacaoRepository repository)
        {
            _repository = repository;
        }
        

       public async Task<Transacao>AdicionarAsync(CriarTransacaoDto dto)
{
    if (dto.Valor == 0)
    {
        throw new Exception("O Valor da transação não pode ser zero.");
    }

    if (string.IsNullOrWhiteSpace(dto.Descricao))
    {
        throw new Exception("A Descrição é obrigatória.");
    }

    
    var novaTransacao = new Transacao
    {
        Id = Guid.NewGuid(),
        Data = DateTime.UtcNow,
        Descricao = dto.Descricao,
        Valor = dto.Valor,
        Tipo = dto.Tipo
    };

    
    

    await _repository.AddAsync(novaTransacao);
    await _repository.SaveChangesAsync(); 

    return novaTransacao;
}
    public async Task<IEnumerable<Transacao>> ObterTodasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Transacao?>ObterPorIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

}