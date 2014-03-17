using Erp.Business.Enum;

namespace Erp.Business.Entity.GestaoDeArquivos
{
    public class TipoArquivoDigital
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Status Status { get; set; }
    }
}