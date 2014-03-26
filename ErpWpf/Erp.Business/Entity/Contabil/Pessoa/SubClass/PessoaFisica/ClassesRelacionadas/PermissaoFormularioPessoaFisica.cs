using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.ClassesRelacionadas
{
    public class PermissaoFormularioPessoaFisica
    {
        public virtual Formulario Formulario { get; set; }
        public virtual bool Pesquisa { get; set; }
        public virtual bool Insere { get; set; }
        public virtual bool Exclui { get; set; }
    }
}
