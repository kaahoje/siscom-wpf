using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum SpedInstituicaoResponsavel
    {
        [Display(Name = "SECRETARIA DA RECEITA FEDERAL")] Rf,
        [Display(Name = "BANCO CENTRAL DO BRASIL (COSIF)")] Cosif
    }
}