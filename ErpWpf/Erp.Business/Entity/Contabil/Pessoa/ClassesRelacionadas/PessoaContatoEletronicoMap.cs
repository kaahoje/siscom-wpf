using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que define o mapeiamendo da classe "ContatoEletronico" para o banco de dados.
    /// </summary>
    public class PessoaContatoEletronicoMap : ClassMap<PessoaContatoEletronico>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public PessoaContatoEletronicoMap()
        {
            Id(x => x.Id).GeneratedBy.Native().Not.Nullable().Unique();
            Map(x => x.Status);
            

            Map(x => x.Nick).Not.Nullable().Length(60);

            Map(x => x.Tipo).CustomType<int>().Not.Nullable();

            References(x => x.Pessoa).Column("pessoa_id");

            Table("PessoaContatoEletronico");

        }
    }
}