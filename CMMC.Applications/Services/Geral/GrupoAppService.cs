using System;
using System.Threading.Tasks;
using CMMC.Domain.Entities;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.Repositories;
using CMMC.Domain.Interfaces.Services.Geral;
using CMMC.Domain.ViewModels;

namespace CMMC.Applications.Services.Geral
{
    public class GrupoAppService : CriacaoAlteracaoAppServiceBase<Grupo>,IGrupoAppService
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

        public Task Excluir(GrupoViewModel entity, string usuario)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }
            return Task.FromResult(base.Excluir(entity.ID, usuario));
        }

        public Task<GrupoViewModel> Novo(GrupoViewModel entity, string usuario)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var grupo = new Grupo(usuario)
            {
                Nome = entity.nome
            };

            var novogrupo = base.Novo(grupo, usuario);

            return Task.FromResult(new GrupoViewModel()
            {
                ID = novogrupo.Result.Id,
                nome = novogrupo.Result.Nome
            });
        }

        public Task<GrupoViewModel> Alterar(GrupoViewModel entity, string usuario)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var grupo = LerPorId(entity.ID).Result;
            if (grupo != null)
            {
                grupo.Nome = entity.nome;
            }
            var novogrupo = base.Alterar(grupo, usuario);
            return Task.FromResult(new GrupoViewModel()
            {
                ID = novogrupo.Result.Id,
                nome = novogrupo.Result.Nome
            });

        }
    }
}