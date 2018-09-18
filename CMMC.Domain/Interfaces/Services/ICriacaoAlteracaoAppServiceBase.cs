using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;

namespace CMMC.Domain.Interfaces.Services
{
    public interface ICriacaoAlteracaoAppServiceBase<TEntity> : IDisposable where TEntity : CriacaoAlteracaoBasicEntity
    {
        Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<List<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> LerPorId(int id);

        Task<TEntity> Novo(TEntity entity, string usuario);
        Task<TEntity> Alterar(TEntity entity, string usuario);
        Task Excluir(TEntity entity, string usuario);
        Task Excluir(int id, string usuario);
    }
}