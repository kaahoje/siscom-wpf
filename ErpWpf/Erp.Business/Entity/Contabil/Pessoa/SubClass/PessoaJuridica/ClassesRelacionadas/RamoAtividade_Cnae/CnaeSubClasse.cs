using System.Collections.Generic;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeSubClasse
    {
    //    [Display(Description = "CNAE da empresa.", Name = "Ramo de Atividade - CNAE")]
    //    [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual int Id { get; set; }

        public virtual string Codigo { get; set; }

       
        public virtual string Denominacao { get; set; }


        public virtual CnaeClasse Classe { get; set; }

        public virtual IList<PessoaJuridicaXcnaeSubClasse> Empresas { get; set; }

         public CnaeSubClasse()
        {
            Empresas = new List<PessoaJuridicaXcnaeSubClasse>();
        }
    }
}