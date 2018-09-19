using CMMC.Domain.Entities;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.ViewModels;
using CMMC.Domain.ViewModels;
using System.Threading.Tasks;

namespace CMMC.Domain.Interfaces.Services
{
    public interface ICriacaoAlteracaoVMAppServiceBase<TEntity, TViewModel> : ICriacaoAlteracaoAppServiceBase<TEntity> 
        where TEntity: CriacaoAlteracaoBasicEntity 
        where TViewModel : IBasicEntityViewModel<TEntity, TViewModel>
    {
        Task<TViewModel> Novo(TViewModel entityVM, string usuario);
        Task<TViewModel> Alterar(TViewModel entityVM, string usuario);
        Task Excluir(TViewModel entityVM, string usuario);
    }
}