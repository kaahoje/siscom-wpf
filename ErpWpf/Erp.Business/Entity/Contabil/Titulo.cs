using System;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    public class Titulo
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataLancamento { get; set; }
        public virtual DateTime DataVencimento { get; set; }
        public virtual DateTime Baixa { get; set; }
        public virtual String NumeroOrdem { get; set; }
        public virtual Decimal Valor { get; set; }
        public virtual Decimal Juros { get; set; }
        public virtual Decimal Acressimos { get; set; }
        public virtual DateTime DescontoAte { get; set; }
        public virtual Decimal DescontoPercentual { get; set; }
        public virtual Decimal Desconto { get; set; }
        public virtual bool AReceber { get; set; }
        public virtual string Historico { get; set; }
        public virtual bool Baixado { get; set; }

        public virtual decimal ValorTotal
        {
            get { return Valor - Desconto + Acressimos + Juros; }
        }

        public virtual Pessoa.Pessoa Pessoa { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
        public virtual TipoLancamento TipoLancamento { get; set; }
        public virtual Lancamento Lancamento { get; set; }
        public virtual Status Status { get; set; }
    }
}