using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que define a estrutura de registro de uma unidade da federação.
    /// </summary>
    [Serializable]
    public class EnderecoEstado
    {
        /// <summary>
        ///     Construtor de classe.
        /// </summary>
        public EnderecoEstado()
        {
            Cidades = new List<EnderecoCidade>();
        }

        /// <summary>
        ///     Campo identificador do estado.
        /// </summary>
        [XmlElement("Id")]
        public virtual int Id { get; set; }

        /// <summary>
        ///     Sigla da unidade da unidade da federação.
        /// </summary>
        [XmlElement("UF")]
        public virtual string UF { get; set; }

        /// <summary>
        ///     Nome da unidade da federação.
        /// </summary>
        [XmlElement("Nome")]
        public virtual string Nome { get; set; }

        /// <summary>
        ///     Referência ao país ao qual pertence o estado.
        /// </summary>
        [XmlIgnore]
        public virtual EnderecoPais Pais { get; set; }

        /// <summary>
        ///     Lista de cidades contidas no estado.
        /// </summary>
        [XmlIgnore]
        public virtual IList<EnderecoCidade> Cidades { get; set; }
    }

    /// <summary>
    ///     Classe que mapeia o arquivo XML de estados.
    /// </summary>
    [Serializable]
    [XmlRoot("ColecaoEstados")]
    public class ColecaoEstados
    {
        /// <summary>
        ///     Lista de estados da federação contida no arquivo XML.
        /// </summary>
        [XmlArray("Estados")]
        [XmlArrayItem("Estado", typeof (EnderecoEstado))]
        public List<EnderecoEstado> Estado { get; set; }
    }
}