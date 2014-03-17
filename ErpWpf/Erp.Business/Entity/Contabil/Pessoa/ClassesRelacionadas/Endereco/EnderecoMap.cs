using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que mapeia um endereço para o banco de dados.
    /// </summary>
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Id(x => x.Id).GeneratedBy.Sequence("sqEndereco");

            Map(x => x.Nome).Not.Nullable().Length(200);
            Map(x => x.Cep).Not.Nullable().Length(8);


            References(x => x.Cidade).Cascade.SaveUpdate().Column("cidade_id");
            References(x => x.Bairro).Cascade.SaveUpdate().Column("bairro_id");
        }
    }
}