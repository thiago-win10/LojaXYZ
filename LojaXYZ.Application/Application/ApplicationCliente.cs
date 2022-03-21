using LojaXYZ.Application.Interfaces;
using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Application
{
    public class ApplicationCliente : IApplicationCliente
    {

        private readonly IClienteService _clienteService;
        public ApplicationCliente(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _clienteService.GetClientesAsync();
        }
        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _clienteService.FindByIdAsync(id);
        }
        public async Task InsertAsync(Cliente cliente)
        {
            await _clienteService.InsertAsync(cliente);
        }
        public async Task UpdateAsync(Cliente cliente)
        {
            await _clienteService.UpdateAsync(cliente);

        }
        public async Task DeleteAsync(int id)
        {
            await _clienteService.DeleteAsync(id);
        }

    }
}

