using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Interfaces.Repositories;
using CMMC.Domain.Interfaces.Services;

namespace CMMC.Applications.Services
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : BasicEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public AppServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _repository.Ler(filter, orderBy, includeProperties);
        }

        public Task<List<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return _repository.LerTodosPagina(numeroPagina, itensPorPagina, orderBy);
        }

        public Task<TEntity> LerPorId(int id)
        {
            return _repository.LerPorId(id);
        }

        public async Task<TEntity> Novo(TEntity entity)
        {
            var e = _repository.Novo(entity);
            if (await _repository.Salvar() > 0)
            {
                return e;
            }
            else
            {
                throw new Exception("Problemas ao salvar");
            }
        }

        public async Task<TEntity> Alterar(TEntity entity)
        {
            var e= _repository.Alterar(entity);
            if (await _repository.Salvar() > 0)
            {
                return e;
            }
            else
            {
                throw new Exception("Problemas ao salvar");
            }
        }

        public async Task Excluir(TEntity entity)
        {
            _repository.Excluir(entity);
            await _repository.Salvar();
        }

        public async Task Excluir(int id)
        {
            var entity = _repository.LerPorId(id).Result;
            await this.Excluir(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _repository.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}