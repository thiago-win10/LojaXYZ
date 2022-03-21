using LojaXYZ.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaXYZ.Infrastructure.Mapping
{
    public class ClienteEnderecoMap : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {

            builder.ToTable("ClienteEndereco");
            builder.HasKey(c => c.ClienteEnderecoId);
            builder.Property(x => x.ClienteEnderecoId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Logradouro)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Numero)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Complemento)
                .HasMaxLength(100);

            builder.Property(c => c.Bairro)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cep)
                .HasColumnType("char(9)");

            builder.Property(c => c.Uf)
                .HasColumnType("char(2)");

        }
    }
}
