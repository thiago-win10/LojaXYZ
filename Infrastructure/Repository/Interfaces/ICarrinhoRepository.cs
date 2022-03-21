﻿using LojaXYZ.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository.Interfaces
{
    public interface ICarrinhoRepository
    {
        public Task<List<Carrinho>> GetCarrinhoAsync();
        public Task<Carrinho> FindByIdAsync(int id);
        public Task InsertAsync(Carrinho carrinho);
        public Task UpdateAsync(Carrinho carrinho);
        public Task DeleteAsync(int id);
    }
}