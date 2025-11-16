using FinancasPessoais.Api.Interface;

using FinancasPessoais.Api.Models;
using FinancasPessoais.Api.Dtos;

namespace FinancasPessoais.Api.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _repository;
        public TransacaoService(ITransacaoRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Transacao> ObterTodas()
        {
            return _repository.GetAll();
        }

       public Transacao Adicionar(CriarTransacaoDto dto)
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
    

    _repository.Add(novaTransacao);
    _repository.SaveChanges(); 

    return novaTransacao;
}
    }
}