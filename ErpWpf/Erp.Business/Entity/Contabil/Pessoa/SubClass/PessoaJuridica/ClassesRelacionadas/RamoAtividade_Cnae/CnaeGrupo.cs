using System.Collections.Generic;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeGrupo{
       
        public virtual int Id { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Denominacao { get; set; }

        public virtual CnaeDivisao Divisao { get; set; }


        public virtual IList<CnaeClasse> Classes { get; set; }

        public CnaeGrupo()
        {
            Classes = new List<CnaeClasse>();
        }
    }
}
