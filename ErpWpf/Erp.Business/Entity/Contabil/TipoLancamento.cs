using System;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Contabil
{
    /// <summary>
    ///     Define os tipos de lançamento
    ///     Esta informação deve ser omitida caso o cliente use o sistema para gerar SPED contábil.
    /// </summary>
    [Serializable]
    public class TipoLancamento
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }

        /// <summary>
        ///     Marca se trata-se de um crédito ou débito.
        /// </summary>
        public virtual bool Credito { get; set; }

        /// <summary>
        ///     Define a conta que foi movimentada na operação.
        /// </summary>
        public virtual PlanoContaReferencial ContaPartidaValor { get; set; }

        public virtual PlanoContaReferencial ContaPartidaJuros { get; set; }

        public virtual PlanoContaReferencial ContaPartidaDesconto { get; set; }

        public virtual PlanoContaReferencial ContaPartidaAcressimos { get; set; }

        public virtual PlanoContaReferencial ContaContraPartidaValor { get; set; }

        public virtual PlanoContaReferencial ContaContraPartidaJuros { get; set; }

        public virtual PlanoContaReferencial ContaContraPartidaDesconto { get; set; }

        public virtual PlanoContaReferencial ContaContraPartidaAcressimos { get; set; }

        public virtual Status Status { get; set; }
    }
}