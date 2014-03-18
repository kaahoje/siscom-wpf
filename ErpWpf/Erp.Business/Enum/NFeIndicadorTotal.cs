using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NFeIndicadorTotal
    {
        [Display(Name = "O PRODUTO NAO COMPOE O VALOR DA NOTA")] NaoCompoeValorNfe,
        [Display(Name = "O PROUTO COMPOE O VALOR DA NOTA")] CompoeValorNfe
    }
}