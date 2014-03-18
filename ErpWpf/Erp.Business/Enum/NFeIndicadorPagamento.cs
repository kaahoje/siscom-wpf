using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NFeIndicadorPagamento
    {
        [Display(Name = "PAGAMENTO A VISTA")] AVista,
        [Display(Name = "PAGAMENTO A PRAZO")] APrazo,
        [Display(Name = "OUTROS")] Outros
    }
}