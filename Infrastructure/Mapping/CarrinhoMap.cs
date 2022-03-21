using LojaXYZ.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaXYZ.Infrastructure.Mapping
{
    public class CarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("Carrinho");
            builder.HasKey(c => c.CarrinhoId);
            builder.Property(x => x.CarrinhoId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ValorTotal)
                .HasColumnType("decimal(12, 2)");

            //Relacionamentos
            builder.HasMany(x => x.ItemCarrinhos)
               .WithOne(x => x.Carrinho).HasForeignKey(c => c.ItemCarrinhoId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
