using FluentNHibernate.Mapping;

namespace Erp.Business.Entity.Sistema.Seguranca
{
    public class FormularioPermissaoMap : ClassMap<FormularioPermissao>
    {
        public FormularioPermissaoMap()
        {
            Id(x => x.Id).Not.Nullable().Unique().GeneratedBy.Sequence("sqFormularioPermissao");

            Map(x => x.Formulario).Not.Nullable();
            Map(x => x.Acessivel);
            Map(x => x.Delete);
            Map(x => x.Edit);
            Map(x => x.Insert);
        }
    }
}
