using Microsoft.AspNetCore.Mvc;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Service.Interface;
using FluxoCaixa.Domain.Request;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {

        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        // POST: api/lancamentos
        [HttpPost]
        public async Task<IActionResult> CriarLancamento([FromBody] LancamentoRequest lancamentoRequest)
        {
            if (lancamentoRequest is null)
            {
                return BadRequest("Dados inválidos.");
            }

            Lancamento lancamento = new Lancamento()
            {
                Descricao = lancamentoRequest.Descricao,
                Tipo = lancamentoRequest.Tipo,
                Valor = lancamentoRequest.Valor,
            };

            var resultado = await _lancamentoService.CriarLancamento(lancamento);
            return CreatedAtAction(nameof(ObterLancamentoPorId), new { id = resultado.Id }, resultado);
        }

        // GET: api/lancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lancamento>>> ObterLancamentos()
        {
            var lancamentos = await _lancamentoService.ObterLancamentos();
            return Ok(lancamentos);
        }

        // GET: api/lancamentos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Lancamento>> ObterLancamentoPorId(int id)
        {
            var lancamento = await _lancamentoService.ObterLancamentoPorId(id);
            if (lancamento is null)
            {
                return NotFound();
            }
            return Ok(lancamento);
        }

        // DELETE: api/lancamentos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLancamento(int id)
        {
            var lancamento = await _lancamentoService.ObterLancamentoPorId(id);
            if (lancamento is null)
            {
                return NotFound();
            }

            await _lancamentoService.DeletarLancamento(id);
            return NoContent();
        }
    }
}
