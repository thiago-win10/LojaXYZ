using System.Threading.Tasks;

namespace LojaXYZ.Application.Interfaces
{
    public interface IApplicationUsuario
    {
        Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular);
        Task<bool> ExisteUsuario(string email, string senha);
        Task<string> RetornaIdUsuario(string email);

    }
}

