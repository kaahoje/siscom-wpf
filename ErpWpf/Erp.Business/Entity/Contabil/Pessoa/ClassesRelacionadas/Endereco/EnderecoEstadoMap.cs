using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que mapeia "EnderecoEstado" para o banco de dados.
    /// </summary>
    public class EnderecoEstadoMap : ClassMap<EnderecoEstado>
    {
        public EnderecoEstadoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqEnderecoEstado");

            Map(x => x.Nome).Not.Nullable().Length(60);
            Map(x => x.UF).Not.Nullable().Length(2);

            References(x => x.Pais).Column("pais_id");


            HasMany(x => x.Cidades).KeyColumn("estado_id");
        }
    }
}