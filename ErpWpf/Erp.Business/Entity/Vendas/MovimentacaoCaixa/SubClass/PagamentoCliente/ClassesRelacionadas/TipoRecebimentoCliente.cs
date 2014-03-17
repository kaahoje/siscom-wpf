using Erp.Business.Entity.Contabil;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.PagamentoCliente.ClassesRelacionadas
{
    public class TipoRecebimentoCliente
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual TipoLancamento TipoLancamento { get; set; }

        public virtual int PrazoCompensacao { get; set; }
        public virtual Status Status { get; set; }
    }
}