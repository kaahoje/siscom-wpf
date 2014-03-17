using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum SpedQualificacaoAssinantes
    {
        [Display(Name = "DIRETOR")] Diretor,
        [Display(Name = "CONSELHEIRO DE ADMINISTRACAO")] Conselheiro,
        [Display(Name = "ADMINISTRADOR")] Administrador,
        [Display(Name = "ADMINISTRADOR DE GRUPO")] AdmGrupo,
        [Display(Name = "ADMINISTRADOR DE SOCIEDADE FILIADA")] AdmSociedadeFiliada,
        [Display(Name = "ADMINISTRADOR JURIDICIAL - PESSOA FISICA")] AdmJudicialFisica,
        [Display(Name = "ADMINISTRADOR JUDICIAL - PESSOA JURIDICA - PROFISSIONAL RESPONSAVEL")] AdmJudicialJuridicaResponsavel,
        [Display(Name = "ADMINISTRADOR JUDICIAO/GESTOR")] AdmJudicialJuridicaGestor,
        [Display(Name = "GESTOR JUDICIAL")] GestorJudicial,
        [Display(Name = "PROCURADOR")] Procurador,
        [Display(Name = "INVENTARIANTE")] Inventariante,
        [Display(Name = "LIQUIDANTE")] Liquidante,
        [Display(Name = "INTERVENTOR")] Interventor,
        [Display(Name = "EMPRESARIO")] Empresario,
        [Display(Name = "CONTADOR")] Contador,
        [Display(Name = "OUTROS")] Outros
    }
}