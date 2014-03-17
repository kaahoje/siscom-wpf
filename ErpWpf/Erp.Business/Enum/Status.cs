using System;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum Status
    {
        [Display(Name = "Ativo")]
        Ativo = 0,

        [Display(Name = "Inativo")]
        Inativo = 1,

        [Display(Name = "Bloqueado")]
        Bloqueado = 2,

        [Display(Name = "Excluído")]
        Excluido = 3,

        [Display(Name = "Cancelado")]
        Cancelado = 4,
    }
} 