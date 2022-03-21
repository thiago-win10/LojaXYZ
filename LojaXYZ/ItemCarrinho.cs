namespace LojaXYZ.Entidades
{
    public class ItemCarrinho
    {
        public virtual int ItemCarrinhoId { get; set; }
        public virtual Carrinho Carrinho { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int Quantidade { get; set; }

    }
}
