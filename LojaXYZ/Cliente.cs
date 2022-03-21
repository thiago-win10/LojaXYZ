using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaXYZ.Entidades
{
    public class Cliente
    {
        public static List<Cliente> Clientes = new List<Cliente>();
        public virtual int ClienteId { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Sobrenome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Telefone(opcional)")]
        public string Telefone2 { get; set; }
        public virtual String Email { get; set; }
        
        [Display(Name = "Email(opcional)")]
        public virtual String Email2 { get; set; }
        public virtual IList<ClienteEndereco> ClienteEnderecos { get; set; }
        public virtual IList<Carrinho> Carrinhos { get; set; }
       
        public Cliente()
        {
            ClienteEnderecos = new List<ClienteEndereco>();
            Carrinhos = new List<Carrinho>();
        }

    }
}
