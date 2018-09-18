using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Domain.Interfaces.Services.Geral
{
    public interface IGrupoAppService
    {
        Task<Grupo> BuscarPorNome(string nome);
    }
}