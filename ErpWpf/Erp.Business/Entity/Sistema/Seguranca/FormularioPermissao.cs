using Erp.Business.Enum;

namespace Erp.Business.Entity.Sistema.Seguranca
{
    public class FormularioPermissao
    {
        public virtual int Id { get; set; }
        public virtual Formulario Formulario { get; set; }
        public virtual bool Acessivel { get; set; }
        public virtual bool Edit { get; set; }
        public virtual bool Insert { get; set; }
        public virtual bool Delete { get; set; }
    }
}
