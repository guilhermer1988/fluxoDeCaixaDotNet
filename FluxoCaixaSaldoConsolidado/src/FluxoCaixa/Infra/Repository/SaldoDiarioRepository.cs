using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Data.Context;
using FluxoCaixa.Infra.Interface;

namespace FluxoCaixa.Infra.Repository
{
    public class SaldoDiarioRepository : BaseRepository<SaldoDiario>, ISaldoDiarioRepository
    {
        public SaldoDiarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<SaldoDiario> ObterPorData(DateTime data)
        {
            // Busca o saldo diário para a data especificada
            var result = await _context.SaldoDiario
                .AsNoTracking()
                .FirstOrDefaultAsync(sd => sd.Data == data.Date);

            return result;
        }

    }
}
