using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que mapeia "PessoaEndereco" para o banco de dados.
    /// </summary>
    public class PessoaEnderecoMap : ClassMap<PessoaEndereco>
    {
        /// <summary>
        /// Construtor de classe.
        /// </summary>
        public PessoaEnderecoMap()
        {
            Id(x => x.Id).GeneratedBy.Native();

            Map(x => x.TipoEndereco).CustomType<int>();

            Map(x => x.InformadoManualmente).Not.Nullable();

            Map(x => x.Logradouro).Length(100);

            Map(x => x.Complemento).Length(100);

            Map(x => x.Status).CustomType<int>().Column("status");

            Map(x => x.Numero).Length(10);

            References(x => x.Endereco);

            References(x => x.Pessoa);

            Table("PessoaEndereco");
        }
    }
}
