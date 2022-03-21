using LojaXYZ.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaXYZ.Infrastructure.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.ClienteId);
            builder.Property(x => x.ClienteId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Sobrenome)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.DataNascimento)
                .HasColumnType("date");

            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email2)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Telefone2)
                .HasColumnType("varchar(20)");

            //Relacionamentos
            builder.HasMany(x => x.ClienteEnderecos)
               .WithOne(x => x.Cliente).HasForeignKey(c => c.ClienteEnderecoId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(x => x.Carrinhos)
               .WithOne(x => x.Cliente).HasForeignKey(c => c.CarrinhoId)
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

