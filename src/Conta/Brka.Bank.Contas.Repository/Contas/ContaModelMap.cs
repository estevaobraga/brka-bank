using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brka.Bank.Contas.Repository.Contas
{
    public class ContaModelMap : IEntityTypeConfiguration<ContaModel>
    {
        public void Configure(EntityTypeBuilder<ContaModel> builder)
        {
            builder.HasKey(x => new {x.Id, x.IdUsuario, x.Tipo});

            builder.ToTable("Contas");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(x => x.IdUsuario)
                .HasColumnName("idUsuario");
            
            builder.Property(x => x.CodigoAgencia)
                .HasColumnName("codigoAgencia")
                .HasMaxLength(3);
            
            builder.Property(x => x.Numero)
                .HasColumnName("numero")
                .HasMaxLength(8);
            
            builder.Property(x => x.Digito)
                .HasColumnName("digito")
                .HasMaxLength(1);
            
            builder.Property(x => x.Tipo)
                .HasColumnName("tipo");
            
            builder.Property(x => x.Saldo)
                .HasColumnName("saldo");
        }
    }
}