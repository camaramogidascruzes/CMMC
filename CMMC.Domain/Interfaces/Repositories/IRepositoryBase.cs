using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Infraestructure;

namespace CMMC.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : BasicEntity
    {
        Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> LerSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<PageableReturn<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<TEntity> LerPorId(int id);
        IQueryable<TEntity> Buscar();

        TEntity Novo(TEntity entity);
        TEntity Alterar(TEntity entity);
        void Excluir(TEntity entity);

        Task<int> Salvar();
    }
}