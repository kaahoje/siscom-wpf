using System.ComponentModel;

namespace Ecf.Enum
{
    public enum CupomFiscalAdicional
    {
        [Description("Não Imprime Cupom Adicional")]
        NaoImprime = 0,
        [Description("Imprime Cupom Adicional Simplificado ")]
        ImprimeCupomSimplificado = 1,
        [Description("Imprime Cupom Adicional Detalhado")]
        ImprimeCupomDetalhado = 2,
        [Description("Imprime Cupom Adicional DLL")]
        ImprimeCupomDll = 3
    }
}
