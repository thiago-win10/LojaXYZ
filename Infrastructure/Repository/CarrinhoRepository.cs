using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Configuration;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly Context _carrinho;
        public CarrinhoRepository(Context carrinho)
        {
            _carrinho = carrinho;
        }

        public async Task<List<Carrinho>> GetCarrinhoAsync()
        {
            return await _carrinho.Carrinhos.Include(x => x.ItemCarrinhos).ToListAsync();
        }
        public async Task<Carrinho> FindByIdAsync(int id)
        {
            return await _carrinho.Carrinhos.AsNoTracking().FirstOrDefaultAsync(x => x.CarrinhoId == id);
        }
        public async Task InsertAsync(Carrinho carrinho)
        {
            _carrinho.Carrinhos.Add(carrinho);
            await _carrinho.SaveChangesAsync();

        }
        public async Task UpdateAsync(Carrinho carrinho)
        {
            bool hasAny = await _carrinho.Carrinhos.AnyAsync(x => x.CarrinhoId == carrinho.CarrinhoId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _carrinho.Update(carrinho);
            await _carrinho.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var carrinho = _carrinho.Carrinhos.Find(id);
            _carrinho.Carrinhos.Remove(carrinho);
            await _carrinho.SaveChangesAsync();
        }

    }
}
