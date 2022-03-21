using LojaXYZ.Application.Interfaces;
using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Application
{
    public class ApplicationCarrinho : IApplicationCarrinho
    {
        private readonly ICarrinhoService _carrinhoService;
        public ApplicationCarrinho(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<List<Carrinho>> GetCarrinhoAsync()
        {
            return await _carrinhoService.GetCarrinhoAsync();
        }
        public async Task<Carrinho> FindByIdAsync(int id)
        {
            return await _carrinhoService.FindByIdAsync(id);
        }
        public async Task InsertAsync(Carrinho carrinho)
        {
            await _carrinhoService.InsertAsync(carrinho);
        }
        public async Task UpdateAsync(Carrinho carrinho)
        {
            await _carrinhoService.UpdateAsync(carrinho);

        }
        public async Task DeleteAsync(int id)
        {
            await _carrinhoService.DeleteAsync(id);
        }

    }
}
