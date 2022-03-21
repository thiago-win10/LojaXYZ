﻿using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository.Interfaces
{
    public interface IUsuario
    {
        Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular);
        Task<bool> ExisteUsuario(string email, string senha);
        Task<string> RetornaIdUsuario(string email);
    }
}
