using System.Collections.Generic;

namespace CMMC.Domain.Entities.Geral
{
    public class TipoEmpresa : CriacaoAlteracaoBasicEntity
    {
        public TipoEmpresa()
        {
            Empresas = new List<EmpresasTipos>();
        }

        public string Nome { get; set; }

        public ICollection<EmpresasTipos> Empresas { get; set; }
    }
}