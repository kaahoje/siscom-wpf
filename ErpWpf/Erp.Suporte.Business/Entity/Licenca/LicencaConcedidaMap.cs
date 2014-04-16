using FluentNHibernate.Mapping;

namespace Erp.Suporte.Business.Entity.Licenca
{
    public class LicencaConcedidaMap : SubclassMap<LicencaConcedida>
    {
        public LicencaConcedidaMap()
        {
            Map(x => x.Logradouro).Not.Nullable();
            Map(x => x.Mac).Not.Nullable();
            Map(x => x.NomeCliente).Not.Nullable();
            Map(x => x.Numero).Not.Nullable();
            Map(x => x.Processador).Not.Nullable();
            Map(x => x.SistemaOperacional).Not.Nullable();
            Map(x => x.VersaoSistemaOperacional).Not.Nullable();
            Map(x => x.IdMaquinaCliente).Not.Nullable();
            
        }
    }
}
