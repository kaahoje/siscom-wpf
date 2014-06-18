using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto
{
    /// <summary>
    ///     Classe que define os dados para um produto. Deve-se atentar para o fato de que um produto marcado como filme
    ///     somente poderá ser vendido por meio da tela de pedidos do sistema de retaguarda.
    /// </summary>
    [Serializable]
    public class Produto
    {
        public Produto()
        {
            Receitas = new List<Receita>();
            UltimaCompra = DateTime.Now;
            Tributacao = new Tributacao();
            //Detalhe = new DetalhesProduto();
            //Tributacao = new Tributacao();
        }

        public virtual int Id { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        [StringLength(Constants.MaxLengthNames, MinimumLength = Constants.MinLengthNames, ErrorMessage = Constants.MessageLengthDescriptionError)]
        [Display(Name = "Descrição", Order = 1)]
        public virtual string Descricao { get; set; }

        [Display(Name = "Referencia", Order = 2)]
        public virtual string Referencia { get; set; }
        [Display(Name = "Cód. Barras", Order = 3)]
        public virtual string CodBarra { get; set; }

        [Display(Name = "Núm. cardápio", Order = 4)]
        public virtual int NumeroCardapio { get; set; }

        [Display(Name = "Tamanho", Order = 5)]
        public virtual string Tamanho { get; set; }

        [Range(Constants.MinValorMonetario, Constants.MaxValorMonetario, ErrorMessage = Constants.MessageRangeValorError)]
        [Display(Name = "Preço", Order = 6)]
        public virtual Decimal PrecoVenda { get; set; }

        public virtual Decimal SaldoAtual
        {
            get { return 0; }
        }

        // Enumerações.
        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Iat Iat { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Ippt Ippt { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual SubGrupoProduto SubGrupo { get; set; }

        /// <summary>
        ///     Define se é um produto, mercadoria ou serviço.
        /// </summary>
        public virtual TipoProduto Tipo { get; set; }

        /// <summary>
        ///     Define se o produto final será obtido por receita.
        /// </summary>
        public virtual bool TemReceita { get; set; }

        public virtual IList<Receita> Receitas { get; set; }

        public virtual DateTime UltimaCompra { get; set; }

        public virtual Decimal Custo
        {
            get { return 0; }
        }

        public virtual Decimal CustoMedio
        {
            get { return 0; }
        }


        public virtual Decimal Lucro
        {
            get { return 0; }
        }

        [Display(Name = "Valor Promocional", Order = 1)]
        public virtual Decimal ValorPromocional { get; set; }
        public virtual Decimal SaldoMinimo { get; set; }

        public virtual Tributacao Tributacao { get; set; }

        public virtual Ncm Ncm { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual OrigemProduto Origem { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Unidade UnidadeCompra { get; set; }

        [Required(ErrorMessage = Constants.MessageRequiredError)]
        public virtual Unidade UnidadeVenda { get; set; }
        public virtual Status Status { get; set; }

        public virtual IList<MovimentacaoProduto> Movimentacao { get; set; }
        public virtual decimal QuantidadeAtual { get; set; }
    }
}