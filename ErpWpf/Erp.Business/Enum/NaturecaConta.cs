using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NaturezaConta
    {
        [Display(Name = "CONTAS DE ATIVO")] Ativo,
        [Display(Name = "CONTAS DE PASSIVO")] Passivo,
        [Display(Name = "RESULTADO LIQUIDO")] ResultadoLiquido,
        [Display(Name = "SUPERAVIT/DEFICIT")] SuperavitDeficit,
        [Display(Name = "CUSTOS DE PRODUCAO")] CustosProducao,
        [Display(Name = "OUTRAS")] Outras
    }
}