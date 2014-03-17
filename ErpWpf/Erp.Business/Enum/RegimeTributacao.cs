using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum RegimeTributacao
    {
        [Display(Name = "SIMPLES NACIONAL")] SimplesNacional,
        [Display(Name = "REGIME NORMAL")] RegimeNormal,
        [Display(Name = "SIMPLES NACIONAL-EXCESSO DE SUBLIMITE DE RECEITA BRUTA")] SimplesNacionalExessoSublimite,
        [Display(Name = "TRIBUTACAO NORMAL")] TributacaoNormal
    }
}