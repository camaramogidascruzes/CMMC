using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Infraestructure;

namespace CMMC.Domain.Interfaces.Services
{
    public interface IAppServiceBase<TEntity>: IDisposable where TEntity : BasicEntity
    {
        Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<PageableReturn<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<TEntity> LerPorId(int id);
        Task<TEntity> Novo(TEntity entity);
        Task<TEntity> Alterar(TEntity entity);
        Task Excluir(TEntity entity);
        Task Excluir(int id);
    }
}