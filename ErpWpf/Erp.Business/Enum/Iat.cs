using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum Iat
    {
        [Display(Name = "ARREDONDAMENTO")] Arredondamento,
        [Display(Name = "TRUNCAMENTO")] Truncamento
    }
}