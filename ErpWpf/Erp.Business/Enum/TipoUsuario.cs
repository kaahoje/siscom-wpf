using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoUsuario
    {
        [Display(Name = "Super administrador")] SuperAdministrador,
        [Display(Name = "Administrador")] Administrador,
        [Display(Name = "Usuário")] Usuario,
        [Display(Name = "Caixa")] Caixa
    }
}