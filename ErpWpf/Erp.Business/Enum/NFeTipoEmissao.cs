using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum NFeTipoEmissao
    {
        [Display(Name = "NORMAL")] Normal = 1,
        [Display(Name = "EMISSAO EM CONTINGENCIA COM FORMULARIO DE SEGURANCA")] ContingenciaFs,
        [Display(Name = "EMISSAO EM CONTINGENCIA NO SISTEMA SCAN")] ContingenciaScan,
        [Display(Name = "EMISSAO EM CONTINGENCIA COM DECLARACAO PREVIA")] ContingenciaDpec,
        [Display(Name = "EMISSAO EM CONTINGENCIA COM IMPRESSAO DE DANFE EM FORMULARIO DE SEGURANCA")] ContingenciaFsDa,
        [Display(Name = "EMISSAO EM CONTINGENCIA NA SEFAZ EM AMBIENTE NACIONAL")] ContingenciaSvcAn,
        [Display(Name = "EMISSAO EN CONTINGENCIA NA SEFAZ DO RIO GRANDE DO SUL")] ContingenciaSvcRs
    }
}