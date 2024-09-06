using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Data.Mapping;

namespace FluxoCaixa.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string mySqlConnectionStr = _configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        }

        public DbSet<SaldoDiario> SaldoDiario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SaldoDiarioMap());
        }
    }
}
