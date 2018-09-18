using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Interfaces.Repositories;

namespace CMMC.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BasicEntity
    {
        protected readonly DbContext _context;
        private DbSet<TEntity> _set;

        public RepositoryBase(DbContext context)
        {
            this._context = context;
        }

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = this._context.Set<TEntity>()); }
        }

        public async Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Set.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync<TEntity>();
            }
            else
            {
                return await query.ToListAsync<TEntity>();
            }
        }

        public async Task<TEntity> LerSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Set.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).AsNoTracking().SingleOrDefaultAsync();
            }
            else
            {
                return await query.AsNoTracking().SingleOrDefaultAsync();
            }
        }

        public async Task<List<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            if (orderBy != null)
            {
                return await orderBy(Set.Skip((numeroPagina - 1) * itensPorPagina).Take(itensPorPagina)).AsNoTracking().ToListAsync<TEntity>();

            }
            else
            {
                return await Set.Skip((numeroPagina - 1) * itensPorPagina).Take(itensPorPagina).AsNoTracking().ToListAsync<TEntity>();
            }

        }

        public async Task<TEntity> LerPorId(int id)
        {
            return await Set.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<TEntity> Buscar()
        {
            return Set.AsNoTracking().AsQueryable();
        }

        public TEntity Novo(TEntity entity)
        {
            Set.Add(entity);
            return entity;
        }

        public TEntity Alterar(TEntity entity)
        {

            try
            {
                var entry = _context.Entry(entity);
                try
                {
                    if (entry.State == EntityState.Detached)
                    {
                        _context.Set<TEntity>().Attach(entity);
                        entry = _context.Entry(entity);
                    }
                }
                finally
                {
                    entry.State = EntityState.Modified;
                }
                return entity;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void Excluir(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                Set.Attach(entity);
            }

            Set.Remove(entity);
        }

        public async Task<int> Salvar()
        {
            return await _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _context.Dispose();
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