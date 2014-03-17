using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que mapeia a classe "EnderecoBairro" para uma tabela no banco de dados.
    /// </summary>
    public class EnderecoBairroMap : ClassMap<EnderecoBairro>
    {
        public EnderecoBairroMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqEnderecoBairro");

            Map(x => x.Nome).Not.Nullable().Length(70);
            References(x => x.Cidade).Cascade.SaveUpdate().Column("cidade_id");

            HasMany(x => x.Enderecos).KeyColumn("bairro_id");
        }
    }
}