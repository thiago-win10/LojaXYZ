using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produtoRepository.GetProdutosAsync();
        }
        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _produtoRepository.FindByIdAsync(id);
        }
        public async Task InsertAsync(Produto produto)
        {
            await _produtoRepository.InsertAsync(produto);
        }
        public async Task UpdateAsync(Produto produto)
        {
            await _produtoRepository.UpdateAsync(produto);

        }
        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }

    }
}