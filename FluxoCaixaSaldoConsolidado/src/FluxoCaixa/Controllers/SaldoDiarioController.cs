using Microsoft.AspNetCore.Mvc;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Service.Interface;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoDiarioController : ControllerBase
    {
        private readonly ISaldoDiarioService _saldoDiarioService;

        public SaldoDiarioController(ISaldoDiarioService saldoDiarioService)
        {
            _saldoDiarioService = saldoDiarioService;
        }

        // GET: api/saldodiario/{data}
        [HttpGet("{data}")]
        public async Task<ActionResult<SaldoDiario>> ObterSaldoDiario(DateTime data)
        {
            var saldoDiario = await _saldoDiarioService.ObterSaldoDiarioPorData(data);
            if (saldoDiario is null)
            {
                return NotFound();
            }
            return Ok(saldoDiario);
        }
    }
}
