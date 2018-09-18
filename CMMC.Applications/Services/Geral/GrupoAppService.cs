using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories;
using CMMC.Domain.Interfaces.Services.Geral;

namespace CMMC.Applications.Services.Geral
{
    public class GrupoAppService : AppServiceBase<Grupo>,IGrupoAppService
    {
        private readonly IRepositoryBase<Grupo> _repository;

        public GrupoAppService(IRepositoryBase<Grupo> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Grupo> BuscarPorNome(string nome)
        {
            return await _repository.LerSingleOrDefault(filter: (e => e.Nome == nome));
        }
    }
}