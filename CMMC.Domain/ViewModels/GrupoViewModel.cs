using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMMC.Domain.ViewModels
{
    public class GrupoViewModel
    {
        public GrupoViewModel()
        {
            
        }

        public GrupoViewModel(int id, string nome)
        {
            this.ID = id;
            this.nome = nome;

        }


        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Nome")]
        public string nome { get; set; }
    }
}