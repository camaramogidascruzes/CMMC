using System;
using System.Data.Entity;
using System.Threading.Tasks;
using CMMC.Data.Context;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories.Geral;

namespace CMMC.Data.Repositories.Geral
{
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
    {
        public GrupoRepository(GeralContext context) : base(context)
        {
            if (context == null) throw new ArgumentNullException();
        }

        public async Task<Grupo> BuscarPorNome(string nome)
        {
            return await Set.AsNoTracking().SingleOrDefaultAsync(e => e.Nome == nome);
        }
    }
}