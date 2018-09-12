using CMMC.Domain.Entities.Geral;
using Microsoft.AspNet.Identity;

namespace CMMC.Infraestrutura.Identity
{
    public class IdentityRole : Grupo, IRole<int>
    {
        public IdentityRole(string usuario) : base(usuario)
        {
            
        }


        public string Name
        {
            get { return this.Nome; }
            set { this.Nome = value; }
        }
    }
}