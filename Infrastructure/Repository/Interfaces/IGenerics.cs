using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository.Interfaces
{
    public interface IGenerics<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> BuscaPorId(int Id);
        Task<List<T>> Listar();

    }
}

