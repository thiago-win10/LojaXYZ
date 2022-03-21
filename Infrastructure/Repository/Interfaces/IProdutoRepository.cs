using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        public Task<List<Produto>> GetProdutosAsync();
        public Task<Produto> FindByIdAsync(int id);
        public Task InsertAsync(Produto produto);
        public Task UpdateAsync(Produto produto);
        public Task DeleteAsync(int id);

    }
}
