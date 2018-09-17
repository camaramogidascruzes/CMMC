using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMMC.Domain.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Usuario")]
        [MaxLength(200, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {1} caracteres")]
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter, no mínimo, {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("senha", ErrorMessage = "As senhas não conferem.")]
        public string confirmarsenha { get; set; }

        public List<RoleViewModel> perfis
        {
            get { return _perfis ?? (_perfis = new List<RoleViewModel>()); }
            set { _perfis = value; }
        }

        [DisplayName("Perfil")]
        public int[] perfisSelecionados { get; set; }

        [DisplayName("Gabinete")]
        public int idGabinete { get; set; }

        [DisplayName("Trocar senha no próximo login ?")]
        public bool necessarioAlterarSenha { get; set; }
    }
}