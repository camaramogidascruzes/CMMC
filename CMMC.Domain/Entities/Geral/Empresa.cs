using System.Collections.Generic;
using CMMC.Domain.Entities.Enums;

namespace CMMC.Domain.Entities.Geral
{
    public class Empresa : CriacaoAlteracaoBasicEntity
    {
        public Empresa()
        {
            DocumentoCpfCnpjTipo = TipoDocumento.CPF;
            Endereco = new InformacaoEndereco();
            Contatos = new List<EmpresaContato>();
            Tipos = new List<EmpresasTipos>();
        }

        public string Nome { get; set; }
        public TipoDocumento DocumentoCpfCnpjTipo { get; set; }
        public string DocumentoCpfCnpj { get; set; }
        public InformacaoEndereco Endereco { get; set; }
        public string Observacao { get; set; }

        public ICollection<EmpresaContato> Contatos { get; set; }
        public ICollection<EmpresasTipos> Tipos { get; set; }
    }
}