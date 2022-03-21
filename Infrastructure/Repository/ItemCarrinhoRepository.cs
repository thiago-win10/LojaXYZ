using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Configuration;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository
{
    public class ItemCarrinhoRepository : IItemCarrinhoRepository
    {
        private readonly Context _itemCarrinho;
        public ItemCarrinhoRepository(Context itemCarrinho)
        {
            _itemCarrinho = itemCarrinho;
        }

        public async Task<List<ItemCarrinho>> GetItemCarrinhoAsync()
        {
            return await _itemCarrinho.ItemCarrinhos.ToListAsync();
        }
        public async Task<ItemCarrinho> FindByIdAsync(int id)
        {
            return await _itemCarrinho.ItemCarrinhos.AsNoTracking().FirstOrDefaultAsync(x => x.ItemCarrinhoId == id);
        }
        public async Task InsertAsync(ItemCarrinho itemCarrinho)
        {
            _itemCarrinho.ItemCarrinhos.Add(itemCarrinho);
            await _itemCarrinho.SaveChangesAsync();

        }
        public async Task UpdateAsync(ItemCarrinho itemCarrinho)
        {
            bool hasAny = await _itemCarrinho.ItemCarrinhos.AnyAsync(x => x.ItemCarrinhoId == itemCarrinho.ItemCarrinhoId);
            if (!hasAny)
            {
                throw new Exception("Id not Found");
            }
            _itemCarrinho.Update(itemCarrinho);
            await _itemCarrinho.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var itemCarrinho = _itemCarrinho.ItemCarrinhos.Find(id);
            _itemCarrinho.ItemCarrinhos.Remove(itemCarrinho);
            await _itemCarrinho.SaveChangesAsync();
        }

    }
}

