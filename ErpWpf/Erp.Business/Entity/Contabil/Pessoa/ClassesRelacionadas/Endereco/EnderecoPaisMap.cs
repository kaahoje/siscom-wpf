using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que mapeia a classe "EnderecoPais" para o banco de dados.
    /// </summary>
    public class EnderecoPaisMap : ClassMap<EnderecoPais>
    {
        public EnderecoPaisMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqEnderecoPais");

            Map(x => x.Nome).Not.Nullable().Length(60);
            HasMany(x => x.Estados).KeyColumn("pais_id");
        }
    }
}