using System;
using System.ComponentModel.DataAnnotations;

namespace Erp.Business.Enum
{
    [Serializable]
    public enum OperacaoNotaDaGente
    {
        [Display(Name = "1-VENDA DE MERCADORIA")] Venda = 1,
        [Display(Name = "2-INDUSTRIALIZADAS PELO EMITENTE")] MercadoriaSubstituta = 2,
        [Display(Name = "3-MERCADORIA IMUNE OU SUJEITA A SUBSTITUICAO TRIBUTARIA")] MercadoriaImune = 3
    }
}