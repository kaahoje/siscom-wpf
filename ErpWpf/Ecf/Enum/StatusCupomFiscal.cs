using System.ComponentModel;

namespace Ecf.Enum
{
    public enum StatusCupomFiscal
    {
        [DescriptionAttribute("Não Iniciado")]
        NaoIniciado,
        [DescriptionAttribute("Aberto")]
        Aberto,
        [DescriptionAttribute("Fechado")]
        Fechado,
        [DescriptionAttribute("Em registro de item")]
        EmRegistroItem,
        [DescriptionAttribute("Em totalização")]
        EmTotalizacao,
        [DescriptionAttribute("Em pagamento")]
        EmPagamento,
        [DescriptionAttribute("Em finalização")]
        EmFinalizacao,
        [DescriptionAttribute("Cancelado")]
        Cancelado
    }
}
