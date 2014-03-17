using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica.ClassesRelacionadas.RamoAtividade_Cnae
{
    /// <summary>
    /// Classe que mapeia um endereço para o banco de dados.
    /// </summary>
    public class PessoaJuridicaXcnaeSubClasseMap : ClassMap<PessoaJuridicaXcnaeSubClasse>
    {
        public PessoaJuridicaXcnaeSubClasseMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            References(x => x.Empresa).Column("pessoa_juridica_id").Not.Nullable();

            References(x => x.CnaeSubClasse).Column("cnae_subclasse_id").Not.Nullable();

        }
    }
}
