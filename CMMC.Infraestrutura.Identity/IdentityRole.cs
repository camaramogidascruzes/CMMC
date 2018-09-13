using System.Collections.Generic;
using CMMC.Domain.Entities.Geral;
using Microsoft.AspNet.Identity;

namespace CMMC.Infraestrutura.Identity
{
    public class IdentityRole : Grupo, IRole<int>
    {
        public IdentityRole(Grupo grupo) : base("")
        {
            this.Id = grupo.Id;
            this.Name = grupo.Nome;
            this.Bloqueado = grupo.Bloqueado;
            this.DadosCriacaoRegistro = grupo.DadosCriacaoRegistro;
            this.DadosAlteracaoRegistro = grupo.DadosAlteracaoRegistro;
        }

        public Grupo ToGrupo()
        {
            return new Grupo("")
            {
                Id = this.Id,
                Nome = this.Name,
                Bloqueado = this.Bloqueado,
                DadosCriacaoRegistro = this.DadosCriacaoRegistro,
                DadosAlteracaoRegistro = this.DadosAlteracaoRegistro
                
            };
        }

        public static IEnumerable<IdentityRole> ToList(List<Grupo> grupos)
        {
            foreach (Grupo gr in grupos)
            {
                yield return new IdentityRole(gr);
            }
        }

        public string Name
        {
            get { return this.Nome; }
            set { this.Nome = value; }
        }
    }
}