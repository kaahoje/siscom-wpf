using System;
using Erp.Business.Enum;

namespace Erp.Business.Entity.Sped
{
    [Serializable]
    public class PlanoContaReferencial : IDisposable
    {
        public virtual int Id { get; set; }

        /// <summary>
        ///     Campo identificador do plano de contas.
        /// </summary>
        public virtual String Codigo { get; set; }

        public virtual String Descricao { get; set; }
        public virtual String Orientacoes { get; set; }

        public virtual TipoConta Tipo { get; set; }

        public virtual int Nivel
        {
            get { return PlanoContaReferencialRepository.NivelConta(Id); }
        }

        public virtual NaturezaConta NaturezaConta { get; set; }

        public void Dispose()
        {
        }
    }
}