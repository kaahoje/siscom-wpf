using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas
{
    /// <summary>
    /// Classe que mapeia "Telefone" para o banco de dados.
    /// </summary>
    class PessoaTelefoneMap : ClassMap<PessoaTelefone>
    {
        /// <summary>
        /// Construtor de classe.
        /// </summary>
        public PessoaTelefoneMap()
        {
            Id(x => x.Id).GeneratedBy.Native().Not.Nullable().Unique();

            Map(x => x.DdiPais).Length(3).Not.Nullable().Column("ddi_pais");

            Map(x => x.DddTelefone).Length(3).Not.Nullable().Column("ddi_telefone");
          
            Map(x => x.Numero).Length(9).Not.Nullable().Column("numero");

            Map(x => x.Ramal).Length(6).Column("ramal").Default("''");
            
            Map(x => x.TelefoneTipo).CustomType<int>().Column("telefone_tipo");

            Map(x => x.Status).CustomType<int>().Column("status");

            References(x => x.Pessoa).Column("pessoa_id").Not.Nullable();

            Table("PessoaTelefone");
        }
    }
}