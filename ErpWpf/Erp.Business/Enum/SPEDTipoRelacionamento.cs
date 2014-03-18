using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum SpedTipoRelacionamento
    {
        [Display(Name = "MATRIZ NO EXTERIOR")] Matriz = 1,
        [Display(Name = "FILIAL, INCLUSIVE AGENCIA OU DEPENDENCIA NO EXTERIOR")] Filial,
        [Display(Name = "COLIGADA, INCLUSIVE EQUIPARADA")] Coligada,
        [Display(Name = "CONTROLADORA")] Controladora,
        [Display(Name = "CONTROLADA (EXCETO SUBSIDIARIA INTEGRAL)")] Controlada,
        [Display(Name = "SUBSIDIARIA INTEGRAL")] Subsidiaria,
        [Display(Name = "CONTROLADA EM CONJUNTO")] ControladaEmComjunto,
        [Display(Name = "ENTIDADE DE PROPOSITO ESPECIFICO")] EntidadePropositoEspecifico,
        [Display(Name = "PARTICIPANTE DO CONGLOMERADO")] ParticipanteConglomerado,
        [Display(Name = "LOCALIZADA EM PAIS COM TRIBUTACAO FAVORECIDA")] LocalizadaPaisFavorecido
    }
}