using System.Collections.Generic;
using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;
using System.Linq;
using System.Runtime.InteropServices;

namespace CMMC.Domain.Interfaces.Repositories.Geral
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> LerUsuarioPorId(int id);
        Task<Usuario> BuscarPorNome(string username);
        IQueryable<Usuario> BuscarUsuario();
        Task<List<Grupo>> ListarGrupos(int usuarioId);

    }
}