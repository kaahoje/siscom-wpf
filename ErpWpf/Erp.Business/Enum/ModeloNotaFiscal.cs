using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum ModeloNotaFiscal
    {
        [Display(Name = "D")]
        D = 0,
        [Display(Name = "NF-E")]
        NFe = 1,
        [Display(Name = "A1")]
        ModeloA1 = 2,
        [Display(Name = "1A")]
        Modelo1A = 3,
        [Display(Name = "NF. DE VENDA AO CONSUMIDOR ONLINE")]
        NfvcOnline = 4
    }
}