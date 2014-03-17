using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Annotations;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Fiscal;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Enum;
using NHibernate.Type;
using Remotion.Linq.Collections;

namespace Erp.Business.Entity.Vendas.Pedido
{
    [Serializable]
    public class Pedido
    {
        public Pedido()
        {
            Pagamento = new ObservableCollection<PagamentoPedido>();
            DataPedido = DateTime.Now;
            Id = 0;
        }
        [Display(Name = "Número", Description = "Número do pedido")]
        [GridAnnotation(Order = 0, Visible = true, Width = 150)]
        public virtual int Id { get; set; }

        public virtual int Coo { get; set; }

        [Display(Name = "Data", Description = "Data do pedido")]
        [DisplayFormat(DataFormatString = Constants.MaskDate)]
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [GridAnnotation(Order = 1, Visible = true, Width = 100)]
        public virtual DateTime DataPedido { get; set; }
        public virtual decimal Acressimos { get; set; }
        public virtual decimal Frete { get; set; }
        public virtual decimal Descontos { get; set; }
        public virtual decimal ValorPedido { get; set; }
        public virtual int Caixa { get; set; }

        /// <summary>
        ///     Pessoa que está comprando da empresa.
        ///     Caso seja necessário a utilização de limites ou informações especificas de clientes o mesmo deve
        ///     ser cadastrado pelo formulário de cliente.
        /// </summary>
        public virtual Pessoa Cliente { get; set; }

        public virtual PessoaJuridica Empresa { get; set; }
        public virtual PessoaFisica Usuario { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }

        public virtual CondicaoPagamento CondicaoPagamento { get; set; }
        public virtual IList<PagamentoPedido> Pagamento { get; set; }

        [Display(Name = "Observações", Description = "Observações do pedido")]
        [GridAnnotation(Order = 2,Visible = true, Width = 300)]
        public virtual string Observacoes { get; set; }
        public virtual Status Status { get; set; }
    }
}