using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Configuration;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _produto;
        public ProdutoRepository(Context produto)
        {
            _produto = produto;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produto.Produtos.ToListAsync();
        }
        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _produto.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.ProdutoId == id);
        }
        public async Task InsertAsync(Produto produto)
        {
            _produto.Produtos.Add(produto);
            await _produto.SaveChangesAsync();

        }
        public async Task UpdateAsync(Produto produto)
        {
            bool hasAny = await _produto.Produtos.AnyAsync(x => x.ProdutoId == produto.ProdutoId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _produto.Update(produto);
            await _produto.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var produto = _produto.Produtos.Find(id);
            _produto.Produtos.Remove(produto);
            await _produto.SaveChangesAsync();
        }

    }
}
