using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Domain.ViewModels
{
    public class AlteraSenhaViewModel
    {
        public AlteraSenhaViewModel()
        {
            
        }

        public AlteraSenhaViewModel(int id, string login)
        {
            this.usuarioId = id;
            this.usuario = login;
        }


        [Key]
        public int usuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Usuario")]
        [MaxLength(200, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter, no mínimo, {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string senhaantiga { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter, no mínimo, {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nova Senha")]
        [Compare("senha", ErrorMessage = "As senhas não conferem.")]
        public string confirmarsenha { get; set; }
    }
}
