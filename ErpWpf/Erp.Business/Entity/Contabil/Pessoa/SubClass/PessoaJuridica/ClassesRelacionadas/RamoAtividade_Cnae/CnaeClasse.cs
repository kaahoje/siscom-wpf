using System.Collections.Generic;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeClasse
    {
        public virtual int Id { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Denominacao { get; set; }

        public virtual CnaeGrupo Grupo { get; set; }


        public virtual IList<CnaeSubClasse> SubClasses { get; set; }

        public CnaeClasse()
        {
            SubClasses = new List<CnaeSubClasse>();
        }
    }
}
