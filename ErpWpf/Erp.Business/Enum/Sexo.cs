using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum Sexo
    {
        [Display(Name = "Masculino")]
        Masculino = 1,
        [Display(Name = "Feminino")]
        Feminino = 2,
    }
}