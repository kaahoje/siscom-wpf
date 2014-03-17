using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sped
{
    public class SpedInstituicaoResponsavelCadastroMap : ClassMap<SpedInstituicaoResponsavelCadastro>
    {
        public SpedInstituicaoResponsavelCadastroMap()
        {
            Id(x => x.Codigo).Not.Nullable();

            Map(x => x.Descricao).Not.Nullable();
        }
    }
}