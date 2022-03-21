using LojaXYZ.Application.Interfaces;
using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Application
{
    public class ApplicationItemCarrinho : IApplicationItemCarrinho
    {
        private readonly IITemCarrinhoService _itemCarrinhoService;
        public ApplicationItemCarrinho(IITemCarrinhoService itemCarrinhoService)
        {
            _itemCarrinhoService = itemCarrinhoService;
        }

        public async Task<List<ItemCarrinho>> GetItemCarrinhoAsync()
        {
            return await _itemCarrinhoService.GetItemCarrinhoAsync();
        }
        public async Task<ItemCarrinho> FindByIdAsync(int id)
        {
            return await _itemCarrinhoService.FindByIdAsync(id);
        }
        public async Task InsertAsync(ItemCarrinho itemCarrinho)
        {
            await _itemCarrinhoService.InsertAsync(itemCarrinho);
        }
        public async Task UpdateAsync(ItemCarrinho itemCarrinho)
        {
            await _itemCarrinhoService.UpdateAsync(itemCarrinho);

        }
        public async Task DeleteAsync(int id)
        {
            await _itemCarrinhoService.DeleteAsync(id);
        }
    }
}
