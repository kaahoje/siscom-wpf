using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica
{
    public class PessoaFisicaMap : SubclassMap<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            Map(x => x.Alias);
            Map(x => x.Cpf).Unique();
            Map(x => x.Nome);
            Map(x => x.Sexo);
            Map(x => x.Login).Unique();
            Map(x => x.Senha);
            Map(x => x.UltimaVisita);
            Map(x => x.VisitaAtual);
            Map(x => x.TemaPadrao);
            Map(x => x.IdiomaPadrao);
            Map(x => x.ModoEdicaoGridView);
            Map(x => x.PalavraChave);

            HasMany(x => x.PermissaoFormulario).Cascade.All();
            HasMany(x => x.PermissaoRelatorio).Cascade.All();
        }
    }
}
