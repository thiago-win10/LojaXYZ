using LojaXYZ.Application.Interfaces;
using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Application.Application
{
    public class ApplicationProduto : IApplicationProduto
    {
        private readonly IProdutoService _produtoService;
        public ApplicationProduto(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produtoService.GetProdutosAsync();
        }
        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _produtoService.FindByIdAsync(id);
        }
        public async Task InsertAsync(Produto produto)
        {
            await _produtoService.InsertAsync(produto);
        }
        public async Task UpdateAsync(Produto produto)
        {
            await _produtoService.UpdateAsync(produto);

        }
        public async Task DeleteAsync(int id)
        {
            await _produtoService.DeleteAsync(id);
        }

    }
}
