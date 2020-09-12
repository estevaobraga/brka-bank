using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brka.Bank.Contas.Repository.Transacoes
{
    public class TransacoesModelMap : IEntityTypeConfiguration<TransacaoModel>
    {
        public void Configure(EntityTypeBuilder<TransacaoModel> builder)
        {
            builder.ToTable("Transacao");

            builder.HasKey(x => new {x.Id, x.IdConta, x.IdUsuario});

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.IdConta)
                .IsRequired()
                .HasColumnName("idConta");

            builder.Property(x => x.IdUsuario)
                .IsRequired()
                .HasColumnName("idUsuario");
            
            builder.Property(x => x.DataTrasacao)
                .IsRequired()
                .HasColumnName("dataTransacao");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("valor");

            builder.Property(x => x.TipoTransacao)
                .IsRequired()
                .HasColumnName("tipoTransacao");
            
            builder.Property(x => x.SaldoEmConta)
                .IsRequired()
                .HasColumnName("saldoEmConta");
        }
    }
}