using System.ComponentModel.DataAnnotations;

namespace CMMC.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }
    }
}
