using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Infra.Data.Mapping
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamentos");

            builder.HasKey(e => e.Id)
                .HasName("PK_Lancamentos");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Configuração para geração automática incremental

            builder.Property(e => e.Tipo)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (TipoLancamento)Enum.Parse(typeof(TipoLancamento), v))
                .HasMaxLength(50);

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasMaxLength(255);

            builder.Property(e => e.Data)
                .IsRequired();
        }
    }
}
