using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Domain.Interfaces.Services.Geral
{
    public interface IGrupoAppService : IAppServiceBase<Grupo>
    {
        Task<Grupo> BuscarPorNome(string nome);
    }
}