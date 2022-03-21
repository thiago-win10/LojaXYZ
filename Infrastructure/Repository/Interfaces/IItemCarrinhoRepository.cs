using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository.Interfaces
{
    public interface IItemCarrinhoRepository
    {
        public Task<List<ItemCarrinho>> GetItemCarrinhoAsync();
        public Task<ItemCarrinho> FindByIdAsync(int id);
        public Task InsertAsync(ItemCarrinho itemCarrinho);
        public Task UpdateAsync(ItemCarrinho itemCarrinho);
        public Task DeleteAsync(int id);
    }
}
