using System;
using System.Collections.Generic;

namespace CMMC.Domain.Entities.Geral
{
    public class Funcionario : CriacaoAlteracaoBasicEntity
    {
        public Funcionario()
        {
            Documento = new InformacaoDocumento();
            Nascimento = DateTime.MinValue;
            Setor = new Setor();
            Cargos = new List<Ocupacao>();
            Contatos = new List<FuncionarioContato>();

        }

        public string Nome { get; set; }
        public InformacaoDocumento Documento { get; set; }
        public DateTime? Nascimento { get; set; }
        public int? IdSetor { get; set; }
        public Setor Setor { get; set; }

        public ICollection<Ocupacao> Cargos { get; set; }
        public ICollection<FuncionarioContato> Contatos { get; set; }
    }


}