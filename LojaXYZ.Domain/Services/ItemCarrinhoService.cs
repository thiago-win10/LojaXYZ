using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Domain.Services
{
    public class ItemCarrinhoService : IITemCarrinhoService
    {
        private readonly IItemCarrinhoRepository _itemCarrinhoRepository;
        public ItemCarrinhoService(IItemCarrinhoRepository itemCarrinhoRepository)
        {
            _itemCarrinhoRepository = itemCarrinhoRepository;
        }

        public async Task<List<ItemCarrinho>> GetItemCarrinhoAsync()
        {
            return await _itemCarrinhoRepository.GetItemCarrinhoAsync();
        }
        public async Task<ItemCarrinho> FindByIdAsync(int id)
        {
            return await _itemCarrinhoRepository.FindByIdAsync(id);
        }
        public async Task InsertAsync(ItemCarrinho itemCarrinho)
        {
            await _itemCarrinhoRepository.InsertAsync(itemCarrinho);
        }
        public async Task UpdateAsync(ItemCarrinho itemCarrinho)
        {
            await _itemCarrinhoRepository.UpdateAsync(itemCarrinho);

        }
        public async Task DeleteAsync(int id)
        {
            await _itemCarrinhoRepository.DeleteAsync(id);
        }
    }
}