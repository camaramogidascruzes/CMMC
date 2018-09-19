using System;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Interfaces.Repositories;
using CMMC.Domain.Interfaces.Services;
using CMMC.Domain.Interfaces.ViewModels;

namespace CMMC.Applications.Services
{
    public class CriacaoAlteracaoVMAppServiceBase<TEntity, TViewModel> : CriacaoAlteracaoAppServiceBase<TEntity>, ICriacaoAlteracaoVMAppServiceBase<TEntity, TViewModel> where TEntity : CriacaoAlteracaoBasicEntity, new() where TViewModel : IBasicEntityViewModel<TEntity, TViewModel>
    {
        public CriacaoAlteracaoVMAppServiceBase(IRepositoryBase<TEntity> repository) : base(repository)
        {
        }

        public Task<TViewModel> Alterar(TViewModel entityVM, string usuario)
        {
            if (entityVM == null)
            {
                throw new ArgumentNullException(nameof(entityVM));
            }
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var entity = LerPorId(entityVM.Id).Result;
            if (entity != null)
            {
                entity = entityVM.UpdateEntity(entity);
                entity = Alterar(entity, usuario).Result;
            }
            return Task.FromResult(entityVM.ToViewModel(entity));
        }

        public Task Excluir(TViewModel entityVM, string usuario)
        {
            if (entityVM == null)
            {
                throw new ArgumentNullException(nameof(entityVM));
            }
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            return Task.FromResult(base.Excluir(entityVM.Id, usuario));
        }

        public Task<TViewModel> Novo(TViewModel entityVM, string usuario)
        {
            if (entityVM == null)
            {
                throw new ArgumentNullException(nameof(entityVM));
            }
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var entity = new TEntity();
            entity = entityVM.UpdateEntity(entity);

            var novoentity = base.Novo(entity, usuario);

            return Task.FromResult(entityVM.ToViewModel(novoentity.Result));
        }
    }
}