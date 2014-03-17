using System;
using System.ComponentModel.DataAnnotations;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Estoque.Produto.ClassesRelacionadas
{
    public class MovimentacaoProduto
    {
        public virtual int Id { get; set; }

        [Timestamp]
        [Required(ErrorMessage = "O campo dada a movimentação é obrigatório.")]
        public virtual DateTime DataMovimentacao { get; set; }

        public virtual string Documento { get; set; }

        [Required(ErrorMessage = "O campo quantidade é obrigatório.")]
        public virtual Decimal Quantidade { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório.")]
        public virtual Decimal Valor { get; set; }

        public virtual string Observacao { get; set; }

        [Required(ErrorMessage = "O campo entrada/saída é obrigatório.")]
        public virtual EntradaSaida EntradaSaida { get; set; }

        [Required(ErrorMessage = "O campo produto é obrigatório.")]
        public virtual Produto Produto { get; set; }
        public virtual Status Status { get; set; }
    }
}