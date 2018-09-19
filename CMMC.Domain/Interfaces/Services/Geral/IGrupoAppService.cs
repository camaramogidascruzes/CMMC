using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.ViewModels;

namespace CMMC.Domain.Interfaces.Services.Geral
{
    public interface IGrupoAppService : ICriacaoAlteracaoVMAppServiceBase<Grupo,GrupoViewModel>
    {
    }
}