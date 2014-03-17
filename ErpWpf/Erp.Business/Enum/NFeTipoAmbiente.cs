using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NFeTipoAmbiente
    {
        [Display(Name = "PRODUCAO")] Producao = 1,
        [Display(Name = "HOMOLOGACAO")] Homologacao
    }
}