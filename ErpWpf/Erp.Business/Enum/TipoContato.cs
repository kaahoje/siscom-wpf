using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum TipoTelefone
    {
        [Display(Name = "Comercial")] Comercial,
        [Display(Name = "Residêncial")] Residencial,
        [Display(Name = "Celular")] Celular
    }
}