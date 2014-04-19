using Erp.Business.Entity.Trabalhista.ClassesRelacionadas;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Trabalhista
{
    public class Funcionario 
    {
        public virtual int Id { get; set; }
        public virtual int PessoaFisica { get; set; }
        public virtual decimal Salario { get; set; }
        public virtual decimal Gratificacao { get; set; }
        public virtual decimal CargaHoraria { get; set; }
        public virtual CargoFuncionario Cargo { get; set; }
        public virtual Status Status { get; set; }
    }
}
