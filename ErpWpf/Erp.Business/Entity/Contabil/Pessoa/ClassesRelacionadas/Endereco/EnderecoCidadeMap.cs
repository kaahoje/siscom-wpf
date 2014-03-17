using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que mapeia a classe "EnderecoCidade" para o banco de dados.
    /// </summary>
    public class EnderecoCidadeMap : ClassMap<EnderecoCidade>
    {
        public EnderecoCidadeMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqEnderecoCidade");

            Map(x => x.Nome).Not.Nullable().Length(70);
            Map(x => x.CodigoIBGE).Not.Nullable().Length(12);
            Map(x => x.Area).Not.Nullable();

            References(x => x.Estado).Cascade.SaveUpdate().Column("estado_id");

            HasMany(x => x.Enderecos).KeyColumn("cidade_id");
            HasMany(x => x.Bairros).KeyColumn("cidade_id");
        }
    }
}