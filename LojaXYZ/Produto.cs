using System;
using System.Collections.Generic;

namespace LojaXYZ.Entidades
{
    public class Produto
    {
        public static List<Produto> Produtos = new List<Produto>();
        public virtual int ProdutoId { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Descricao { get; set; }
        public virtual double Preco { get; set; }
        public virtual String Foto { get; set; }
    }
}
