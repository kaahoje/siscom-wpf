using System;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class PessoaJuridicaXcnaeSubClasse
    {
        public virtual int Id { get; set; }

        public virtual Guid IdGuid { get; set; }
        
        public virtual PessoaJuridica Empresa { get; set; }
        
        [Display(Description = "CNAE da empresa.", Name = "Ramo de Atividade - CNAE")]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual CnaeSubClasse CnaeSubClasse { get; set; }

        public PessoaJuridicaXcnaeSubClasse()
        {
            IdGuid = Guid.NewGuid();
        }
    }
}