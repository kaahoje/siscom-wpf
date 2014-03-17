using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqPessoa");

            HasMany(x => x.Enderecos).KeyColumn("pessoa_id").Cascade.All();
            HasMany(x => x.ContatoTelefonicos).KeyColumn("pessoa_id").Cascade.All();
            HasMany(x => x.EnderecoEletronicos).KeyColumn("pessoa_id").Cascade.All();
          
            Map(x => x.Status);
        }
    }
}