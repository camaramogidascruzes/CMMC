using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories.Geral;

namespace CMMC.Data.Repositories.Geral
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
            if (context == null) throw new ArgumentNullException();
        }

        public async Task<Usuario> BuscarPorNome(string username)
        {
            return await Set.AsNoTracking().SingleOrDefaultAsync(e => e.Login == username);
        }

        public Task<List<Grupo>> ListarGrupos(int usuarioId)
        {
            var usuario = this.Ler(filter: usr => usr.Id == usuarioId, includeProperties: "Grupos.Grupo").Result
                .FirstOrDefault();

            if (usuario != null)
            {
                var grupos = new List<Grupo>();
                foreach (var g in usuario.Grupos)
                {
                    grupos.Add(g.Grupo);
                }

                return Task.FromResult(grupos);
            }

            return Task.FromResult(new List<Grupo>());
        }

        public IQueryable<Usuario> BuscarUsuario()
        {
            return Set.AsQueryable();
        }
    }
}