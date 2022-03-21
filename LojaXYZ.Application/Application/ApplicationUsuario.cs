using LojaXYZ.Application.Interfaces;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Application
{
    public class ApplicationUsuario : IApplicationUsuario
    {
        IUsuario _usuario;
        public ApplicationUsuario(IUsuario usuario)
        {
            _usuario = usuario;

        }
        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            return await _usuario.AdicionarUsuario(email, senha, idade, celular);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _usuario.ExisteUsuario(email, senha);
        }

        public async Task<string> RetornaIdUsuario(string email)
        {
            return await _usuario.RetornaIdUsuario(email);
        }
    }


}
