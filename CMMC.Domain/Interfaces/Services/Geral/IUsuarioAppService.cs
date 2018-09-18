using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Domain.Interfaces.Services.Geral
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Task<Usuario> LerUsuarioPorId(int id);
        Task<Usuario> BuscarPorNome(string username);
        IQueryable<Usuario> BuscarUsuario();
        Task<List<Grupo>> ListarGrupos(int usuarioId);
        Task AlteraNecessarioAlterarSenha(int id, bool necessarioalterarsenha);
    }
}