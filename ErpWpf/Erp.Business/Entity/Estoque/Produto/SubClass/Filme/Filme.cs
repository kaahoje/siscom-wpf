using System.Collections.Generic;
using Erp.Business.Entity.Estoque.Produto.SubClass.Filme.ClassesRelacionadas;

namespace Erp.Business.Entity.Estoque.Produto.SubClass.Filme
{
    public class Filme : Produto
    {
        /// <summary>
        ///     Este campo pode ser preenchido com o nome original do filme em caso de produção estrangeira.
        /// </summary>
        public virtual string NomeOriginal { get; set; }

        /// <summary>
        ///     Lista de gêneros ao qual pertence o filme.
        /// </summary>
        public virtual IList<Genero> Generos { get; set; }

        /// <summary>
        ///     Propriedade que define o valor de locação quando o filme for um lançamento.
        /// </summary>
        public virtual decimal ValorLocacaoLancamento { get; set; }

        /// <summary>
        ///     Preço praticado quando deixa de ser lançamento.
        /// </summary>
        public virtual decimal ValorLocacao { get; set; }
    }
}