using Erp.Business.Enum;

namespace Erp.Business.Entity.GestaoDeArquivos
{
    public class ArquivoDigital
    {
        public virtual int Id { get; set; }


        public virtual string Md5 { get; set; }
        public virtual string Historico { get; set; }
        public virtual byte[] Arquivo { get; set; }
        public virtual TipoArquivoDigital Tipo { get; set; }
        public virtual Status Status { get; set; }
    }
}