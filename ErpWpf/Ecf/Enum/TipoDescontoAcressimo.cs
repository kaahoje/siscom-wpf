using System.ComponentModel;

namespace Ecf.Enum
{
    public enum TipoDescontoAcressimo
    {
        [Description("Acréssimo em percentual")]
        AcressimoPercentual,
        [Description("Acréssimo em valor")]
        AcressimoValor,
        [Description("Desconto em percentual")]
        DescontoPercentual,
        [Description("Desconto em valor")]
        DescontoValor
    }
}
