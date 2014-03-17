using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    public enum Formulario
    {
        [Display(Name = "Parceiro de negócio pessoa jurídica")]
        ParceiroNegocioPessoaJuridica,
        [Display(Name = "Parceiro de negócio pessoa física")]
        ParceiroNegocioPessoaFisica,
        [Display(Name = "Produto")]
        Produto,
        [Display(Name = "Grupo de produto")]
        GrupoProduto,
        [Display(Name = "Subgrupo de produto")]
        SubGrupoProduto,
        [Display(Name = "Forma de pagamento")]
        FormaPagamento,
        [Display(Name = "Condição de pagamento")]
        CondicaoPagamento,
        [Display(Name = "Pedido")]
        Pedido,
        [Display(Name = "Baixa de título")]
        BaixaTitulo,
        [Display(Name = "Unidade")]
        Unidade,
        [Display(Name = "Ncm")]
        Ncm
    }
}
