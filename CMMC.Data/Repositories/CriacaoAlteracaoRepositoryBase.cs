using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Infraestructure;

namespace CMMC.Data.Repositories
{
    public class CriacaoAlteracaoRepositoryBase<TEntity> : RepositoryBase<TEntity> where TEntity : CriacaoAlteracaoBasicEntity
    {
        public CriacaoAlteracaoRepositoryBase(DbContext context) : base(context)
        {

        }

        public override async Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Set.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter).Where(e => e.Excluido == false);
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

        public override async Task<TEntity> LerSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Set.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter).Where(e => e.Excluido == false);
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

        // Não pode ser assíncrono
        public override async Task<PageableReturn<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = Set.AsNoTracking().Where(e => e.Excluido == false);
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            var p = new PageableReturn<TEntity>();
            p.Total = query.Count();
            p.Itens = await query.Skip((numeroPagina - 1) * itensPorPagina).Take(itensPorPagina).ToListAsync<TEntity>();

            return p;
        }

        public override async Task<TEntity> LerPorId(int id)
        {
            return await Set.AsNoTracking().Where(e => e.Excluido == false).SingleOrDefaultAsync(e => e.Id == id);
        }

        public override IQueryable<TEntity> Buscar()
        {
            return Set.AsNoTracking().Where(e => e.Excluido == false).AsQueryable();
        }

    }
}