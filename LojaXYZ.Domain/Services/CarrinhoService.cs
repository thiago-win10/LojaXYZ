using LojaXYZ.Domain.Services.Interfaces;
using LojaXYZ.Entidades;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Domain.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<List<Carrinho>> GetCarrinhoAsync()
        {
            return await _carrinhoRepository.GetCarrinhoAsync();
        }
        public async Task<Carrinho> FindByIdAsync(int id)
        {
            return await _carrinhoRepository.FindByIdAsync(id);
        }
        public async Task InsertAsync(Carrinho carrinho)
        {
            await _carrinhoRepository.InsertAsync(carrinho);
        }
        public async Task UpdateAsync(Carrinho carrinho)
        {
            await _carrinhoRepository.UpdateAsync(carrinho);

        }
        public async Task DeleteAsync(int id)
        {
            await _carrinhoRepository.DeleteAsync(id);
        }
    }
}
