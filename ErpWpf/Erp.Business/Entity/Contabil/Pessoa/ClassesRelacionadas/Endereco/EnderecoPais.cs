using System;
using System.Collections.Generic;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que define a estrutura de registro de um país.
    /// </summary>
    [Serializable]
    public class EnderecoPais
    {
        /// <summary>
        ///     Construtor de classe.
        /// </summary>
        public EnderecoPais()
        {
            Estados = new List<EnderecoEstado>();
        }

        /// <summary>
        ///     Campo identificador do país.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        ///     Nome do país.
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        ///     Lista de estados contida no país.
        /// </summary>
        public virtual IList<EnderecoEstado> Estados { get; set; }
    }
}