using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CMMC.Data.Context;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories.Geral;

namespace CMMC.Data.Repositories.Geral
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GeralContext context) : base(context)
        {
            if (context == null) throw new ArgumentNullException();
        }


        public async Task<Usuario> LerUsuarioPorId(int id)
        {
            return await Set.AsNoTracking().Include("Grupos").SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Usuario> BuscarPorNome(string username)
        {
            
            return await Set.AsNoTracking().Include("Grupos.Grupo").SingleOrDefaultAsync(e => e.Login == username);
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

        public Task AlteraNecessarioAlterarSenha(int id, bool necessarioalterarsenha)
        {
            var usuario = Set.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.NecessarioAlterarSenha = necessarioalterarsenha;
                return Task.CompletedTask;
            }
            else
            {
                return Task.FromException(new Exception("Usuário não encontrado"));
            }
        }

        public IQueryable<Usuario> BuscarUsuario()
        {
            return Set.AsNoTracking().AsQueryable();
        }
    }
}