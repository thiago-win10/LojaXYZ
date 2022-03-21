using System;
using System.Collections.Generic;

namespace LojaXYZ.Entidades
{
    public class ClienteEndereco
    {

        public static List<ClienteEndereco> ClienteEnderecos = new List<ClienteEndereco>();

        public virtual int ClienteEnderecoId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual String Cep { get; set; }
        public virtual String Logradouro { get; set; }
        public virtual int Numero { get; set; }
        public virtual String Complemento { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Cidade { get; set; }
        public virtual String Uf { get; set; }

    }
}