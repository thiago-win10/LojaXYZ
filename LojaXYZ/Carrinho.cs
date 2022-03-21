using System;
using System.Collections.Generic;

namespace LojaXYZ.Entidades
{
    public class Carrinho
    {
        public virtual int CarrinhoId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Double ValorTotal { get; set; }
        public virtual IList<ItemCarrinho> ItemCarrinhos { get; set; }

        public Carrinho()
        {
            ItemCarrinhos = new List<ItemCarrinho>();
        }

    }
}
