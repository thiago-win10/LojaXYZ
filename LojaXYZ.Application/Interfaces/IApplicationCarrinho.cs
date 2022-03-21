using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Interfaces
{
    public interface IApplicationCarrinho
    {
        public Task<List<Carrinho>> GetCarrinhoAsync();
        public Task<Carrinho> FindByIdAsync(int id);
        public Task InsertAsync(Carrinho carrinho);
        public Task UpdateAsync(Carrinho carrinho);
        public Task DeleteAsync(int id);
    }
}
