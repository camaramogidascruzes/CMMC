namespace CMMC.Domain.Entities.Geral
{
    public class UsuarioGrupo
    {
        public UsuarioGrupo(int usuarioId, int grupoId, string usuario)
        {
            IdUsuario = usuarioId;
            IdGrupo = grupoId;
            DadosCriacaoRegistro = new DadosCriacaoRegistro(usuario);
        }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int IdGrupo { get; set; }
        public Grupo Grupo { get; set; }

        public DadosCriacaoRegistro DadosCriacaoRegistro { get; set; }
    }
}
