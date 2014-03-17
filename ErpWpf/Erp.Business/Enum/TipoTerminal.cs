using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum TipoTerminal
    {
        [Display(Name = "Consulta de preços")] ConsultaPreco,
        [Display(Name = "PDV")] PontoDeVenda,
        [Display(Name = "Gerencial")] Gerencial
    }
}