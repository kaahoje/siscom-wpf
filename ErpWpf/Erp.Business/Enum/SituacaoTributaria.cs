using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum SituacaoTributaria
    {
        [Display(Name = "Tributado")] Tributado,
        [Display(Name = "Isento")] Isento,
        [Display(Name = "Sibstituição tributária")] SubstituicaoTributaria,
        [Display(Name = "Não tributado")] NaoTributado
    }
}