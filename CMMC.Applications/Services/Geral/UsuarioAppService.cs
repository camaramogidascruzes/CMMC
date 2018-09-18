using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories;
using CMMC.Domain.Interfaces.Services.Geral;

namespace CMMC.Applications.Services.Geral
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService 
    {
        private readonly IRepositoryBase<Usuario> _repository;

        public UsuarioAppService(IRepositoryBase<Usuario> repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<Usuario> LerUsuarioPorId(int id)
        {
            return _repository.LerSingleOrDefault(filter: (usr => usr.Id == id), includeProperties: "Grupos");
        }

        public Task<Usuario> BuscarPorNome(string username)
        {
            return _repository.LerSingleOrDefault(filter: (usr => usr.Login == username), includeProperties: "Grupos.Grupo");
        }

        public IQueryable<Usuario> BuscarUsuario()
        {
            return _repository.Buscar();
        }

        public Task<List<Grupo>> ListarGrupos(int usuarioId)
        {
            var usuario = _repository.Ler(filter: usr => usr.Id == usuarioId, includeProperties: "Grupos.Grupo").Result
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

        public async Task AlteraNecessarioAlterarSenha(int id, bool necessarioalterarsenha)
        {
            var usuario = await _repository.LerSingleOrDefault(filter: (u => u.Id == id));
            if (usuario != null)
            {
                usuario.NecessarioAlterarSenha = necessarioalterarsenha;
                _repository.Alterar(usuario);
                await _repository.Salvar();
                return;
            }
            else
            {
                throw new Exception("Usuário não encontrado");
            }
        }
    }
}