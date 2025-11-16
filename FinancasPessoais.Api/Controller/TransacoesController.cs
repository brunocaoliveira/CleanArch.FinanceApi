using FinancasPessoais.Api.Models;
using FinancasPessoais.Api.Data;
using Microsoft.AspNetCore.Mvc;
using FinancasPessoais.Api.Interface;
using FinancasPessoais.Api.Dtos;
using System.Threading.Tasks; 

namespace FinancasPessoais.Api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacaoService _service;

        public TransacoesController(ITransacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTransacao([FromBody] CriarTransacaoDto dto)
        {
            try
            {
                var transacaoCriada = await _service.AdicionarAsync(dto);
                return Ok(transacaoCriada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodasAsTransacoes()
        {
            
            var todasAsTransacoes = await _service.ObterTodasAsync();
            return Ok(todasAsTransacoes);
        }

        
        [HttpGet("{id}")] 
        public async Task<IActionResult> ObterTransacaoPorId(Guid id)
        {
            var transacao = await _service.ObterPorIdAsync(id);

            if (transacao == null)
            {
                return NotFound("Transação não encontrada.");
            }

            return Ok(transacao);
        }
    }
} 