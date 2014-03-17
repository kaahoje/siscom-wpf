using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica
{
    public class PessoaJuridicaMap : SubclassMap<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            Map(x => x.RazaoSocial);

            Map(x => x.NomeFantasia);
            
            Map(x => x.Cnpj).Unique();
            
            Map(x => x.InscricaoEstadual);

            Map(x => x.InscricaoMunicipal);

            Map(x => x.DataAbertura);

            HasMany(x => x.RamosDeAtividade).KeyColumn("pessoa_juridica_id");
        }
    }
}
