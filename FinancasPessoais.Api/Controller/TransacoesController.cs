using FinancasPessoais.Api.Models;
using FinancasPessoais.Api.Data;
using Microsoft.AspNetCore.Mvc;
using FinancasPessoais.Api.Interface;
using FinancasPessoais.Api.Dtos;

namespace FinancasPessoais.Api.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacaoService _service;

        public TransacoesController(ITransacaoService service)
        {
            _service= service;
        }
    

        [HttpPost]
public IActionResult CriarTransacao([FromBody] CriarTransacaoDto dto)
        {
            try
            {
                var transacaoCriada= _service.Adicionar(dto);

                return Ok(transacaoCriada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
        }
        }

        [HttpGet]
        public IActionResult ListarTodasAsTransacoes()
        {
            var todasAsTransacoes = _service.ObterTodas();

            return Ok(todasAsTransacoes);
        }
}


    }

