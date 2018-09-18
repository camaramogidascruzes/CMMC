using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMMC.Domain.Interfaces.Services
{
    public interface IAppServiceBase<TEntity>: IDisposable where TEntity : class
    {
        Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<List<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> LerPorId(int id);
        Task<TEntity> Novo(TEntity entity);
        Task<TEntity> Alterar(TEntity entity);
        Task Excluir(TEntity entity);
        Task Excluir(int id);
    }
}