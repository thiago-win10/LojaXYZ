using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Configuration;
using LojaXYZ.Infrastructure.Repository.Generics;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository
{
    public class UsuarioRepository : RepositoryGeneric<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Context> _optionsBuilder;

        public UsuarioRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }
        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var data = new Context(_optionsBuilder))
                {
                    await data.ApplicationUsers.AddAsync(
                        new ApplicationUser
                        {
                            Email = email,
                            PasswordHash = senha,
                            Idade = idade,
                            Celular = celular
                        });
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var data = new Context(_optionsBuilder))
                {
                    return await data.ApplicationUsers.Where(
                        x => x.Email.Equals(email) && x.PasswordHash.Equals(senha))
                         .AsNoTracking()
                         .AnyAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> RetornaIdUsuario(string email)
        {
            try
            {
                using (var data = new Context(_optionsBuilder))
                {
                    var usuario = await data.ApplicationUsers.Where(
                        x => x.Email.Equals(email))
                         .AsNoTracking()
                         .FirstOrDefaultAsync();

                    return usuario.Id;

                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}

 