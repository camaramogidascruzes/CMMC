using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMMC.Domain.Entities;


namespace Intranet.Domain.Interfaces.Repositories
{
    public interface IRepositoryCriacaoAlteracaoBase<TEntity> : IDisposable where TEntity : CriacaoAlteracaoBasicEntity
    {
        Task<List<TEntity>> Ler(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<List<TEntity>> LerTodosPagina(int numeroPagina, int itensPorPagina, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> LerPorId(int id);

        TEntity Novo(TEntity entity, string usuario);
        TEntity Alterar(TEntity entity, string usuario);
        void Excluir(TEntity entity, string usuario);
        void Excluir(int id, string usuario);

        Task Salvar();
    }
}