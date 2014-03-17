namespace Erp.Business.Entity.Fiscal.ClassesRelacionadas
{
    public class NaturezaInterna
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Cfop Cfop { get; set; }
    }
}