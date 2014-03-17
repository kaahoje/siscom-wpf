using System;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum TipoPessoa
    {
        [Display(Name = "JURIDICA")] JURIDICA,
        [Display(Name = "FISICA")] FISICA
    }
}