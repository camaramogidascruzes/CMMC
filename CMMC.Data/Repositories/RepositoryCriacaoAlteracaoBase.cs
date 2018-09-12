using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using Intranet.Domain.Interfaces.Repositories;

namespace CMMC.Data.Repositories
{
    public class RepositoryCriacaoAlteracaoBase<TEntity> : IRepositoryCriacaoAlteracaoBase<TEntity> where TEntity : CriacaoAlteracaoBasicEntity
    {
        private readonly DbContext _context;
        private DbSet<TEntity> _set;

        public RepositoryCriacaoAlteracaoBase(DbContext context)
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

        public TEntity Novo(TEntity entity, string usuario)
        {
            entity.DadosCriacaoRegistro =
                new DadosCriacaoRegistro(usuario);
            entity.DadosAlteracaoRegistro =
                new DadosAlteracaoRegistro(usuario);
            Set.Add(entity);
            return entity;
        }

        public TEntity Alterar(TEntity entity, string usuario)
        {
            entity.DadosAlteracaoRegistro =
                new DadosAlteracaoRegistro(usuario);
            Set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Excluir(TEntity entity, string usuario)
        {
            entity.Excluido = true;
            this.Alterar(entity, usuario);
        }

        public async void Excluir(int id, string usuario)
        {
            var entity = await this.LerPorId(id);
            this.Excluir(entity, usuario);
        }

        public Task Salvar()
        {
            return _context.SaveChangesAsync();
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