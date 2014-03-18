using System;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum Ippt
    {
        [Display(Name = "PROPRIA")]
        Propria,
        [Display(Name = "TERCEIROS")]
        Terceiros
    }
}