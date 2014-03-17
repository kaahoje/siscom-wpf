using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum LocalPedidoRestaurante
    {
        [Display(Name = "Mesa")] Mesa,
        [Display(Name = "Balcão")] Balcao,
        [Display(Name = "Entrega")] Entrega
    }
}