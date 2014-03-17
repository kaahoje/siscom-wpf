using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum IndicadorTotalizacao
    {
        [Display(Name = "SOMA NA NOTA FISCAL")]
        SomaNotaFiscal,
        [Display(Name = "NAO SOMA NA NOTA FISCAL")]
        NaoSomaNotaFiscal
    }
}