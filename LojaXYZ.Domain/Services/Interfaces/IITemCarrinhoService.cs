using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Domain.Services.Interfaces
{
    public interface IITemCarrinhoService
    {
        public Task<List<ItemCarrinho>> GetItemCarrinhoAsync();
        public Task<ItemCarrinho> FindByIdAsync(int id);
        public Task InsertAsync(ItemCarrinho itemCarrinho);
        public Task UpdateAsync(ItemCarrinho carrinho);
        public Task DeleteAsync(int id);
    }
}
