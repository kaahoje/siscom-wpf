using System.ComponentModel.DataAnnotations;

namespace RestauranteMobile.Models
{
    public class LoginModel
    {
        [Display(Description = "Usuário do sistema",Name = "Usuário")]
        [Required(ErrorMessage = "O usuário deve ser informado")]
        public string Usuario { get; set; }
        [Display(Description = "Senha do usuário do sistema", Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 20 caracteres")]
        public string Senha { get; set; }
    }
}