using LojaXYZ.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaXYZ.Infrastructure.Mapping
{
    public class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.ToTable("ItemCarrinho");
            builder.HasKey(c => c.ItemCarrinhoId);
            builder.Property(x => x.ItemCarrinhoId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Quantidade)
                .HasColumnType("int");

        }
    }
}
