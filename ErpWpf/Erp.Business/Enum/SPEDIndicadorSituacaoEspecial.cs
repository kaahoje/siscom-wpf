using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum SpedIndicadorSituacaoEspecial
    {
        [Display(Name = "ABERTURA")] Abertura,
        [Display(Name = "CISAO")] Cisao,
        [Display(Name = "FUSAO")] Fusao,
        [Display(Name = "INCORPORACAO")] Incorporacao,
        [Display(Name = "ESTINCAO")] Extincao
    }
}