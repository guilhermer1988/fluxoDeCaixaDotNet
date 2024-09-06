using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Infra.Data.Mapping
{
    public class SaldoDiarioMap : IEntityTypeConfiguration<SaldoDiario>
    {
        public void Configure(EntityTypeBuilder<SaldoDiario> builder)
        {
            builder.ToTable("SaldoDiario");

            builder.HasKey(e => e.Data)
                    .HasName("PK_SaldoDiario");

            builder.Property(e => e.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.TotalCredito)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.TotalDebito)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.SaldoFinal)
                .HasColumnType("decimal(18,2)");

            // Configuração de índice único na data
            builder.HasIndex(e => e.Data)
                .IsUnique()
                .HasDatabaseName("IX_SaldoDiario_Data");
        }
    }
}
