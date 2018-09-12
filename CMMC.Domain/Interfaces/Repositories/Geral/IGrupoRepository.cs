using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Domain.Interfaces.Repositories.Geral
{
    public interface IGrupoRepository
    {
        Task<Grupo> BuscarPorNome(string nome);
    }
}