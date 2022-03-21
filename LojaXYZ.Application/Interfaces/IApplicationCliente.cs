using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Interfaces
{
    public interface IApplicationCliente
    {
        public Task<List<Cliente>> GetClientesAsync();
        public Task<Cliente> FindByIdAsync(int id);
        public Task InsertAsync(Cliente cliente);
        public Task UpdateAsync(Cliente cliente);
        public Task DeleteAsync(int id);

    }
}
