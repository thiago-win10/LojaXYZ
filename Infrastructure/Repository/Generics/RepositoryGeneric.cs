using LojaXYZ.Infrastructure.Configuration;
using LojaXYZ.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LojaXYZ.Infrastructure.Repository.Generics
{
    public class RepositoryGeneric<T> : IGenerics<T>, IDisposable where T : class
    {   
        private readonly DbContextOptions<Context> _optionsBuilder;
        public RepositoryGeneric()
        {
            _optionsBuilder = new DbContextOptions<Context>();

        }
        public async Task Adicionar(T Objeto)
        {
            using (var data = new Context(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T Objeto)
        {
            using (var data = new Context(_optionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscaPorId(int Id)
        {

            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }

        }

        public async Task Excluir(T Objeto)
        {

            using (var data = new Context(_optionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }

        }

        public async Task<List<T>> Listar()
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

    }
}

