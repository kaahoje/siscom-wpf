using System.Collections.Generic;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeSecao
    {
        public virtual int Id { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Denominacao { get; set; }

        public virtual IList<CnaeDivisao> Divisoes { get; set; }

        public CnaeSecao()
        {
            Divisoes = new List<CnaeDivisao>();
        }
    }
}
