using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Cliente.PessoaJuridica
{
    public class ClientePessoaJuridicaMap : SubclassMap<ClientePessoaJuridica>
    {
        public ClientePessoaJuridicaMap()
        {
            Map(x => x.Desconto);
            Map(x => x.DescontoAte);
            Map(x => x.JurosAposVencimento);
            Map(x => x.JurosMoraAposVencimento);
            Map(x => x.LimiteLicencas);
            Map(x => x.LimiteSuportePresencial);
            Map(x => x.ValorSuporte);
            HasMany(x => x.Licencas).Cascade.All();
        }
    }
}
