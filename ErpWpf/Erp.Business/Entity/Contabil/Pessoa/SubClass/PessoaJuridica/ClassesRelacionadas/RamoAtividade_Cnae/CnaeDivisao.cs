using System.Collections.Generic;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    public class CnaeDivisao
    {
        public virtual int Id { get; set; }

        public virtual string Codigo { get; set; }

        public virtual string Denominacao { get; set; }

        public virtual CnaeSecao Secao { get; set; }

        public virtual IList<CnaeGrupo> Grupos { get; set; }

        public CnaeDivisao()
        {
            Grupos = new List<CnaeGrupo>();
        }
    }
}