using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que define a estrutura de registro para um bairro.
    /// </summary>
    [Serializable]
    public class EnderecoBairro
    {
        /// <summary>
        ///     Construtor de classe.
        /// </summary>
        public EnderecoBairro()
        {
            Enderecos = new List<Endereco>();
        }

        /// <summary>
        ///     Campo identificador do bairro.
        /// </summary>
        [XmlElement("Id")]
        public virtual int Id { get; set; }

        /// <summary>
        ///     Nome do bairro.
        /// </summary>
        [XmlElement("Nome")]
        public virtual string Nome { get; set; }

        /// <summary>
        ///     Campo que mapeia o identificador de cidade no arquivo XML de bairro.
        /// </summary>
        [XmlElement("Cidade_id")]
        public virtual int Cidade_Id { get; set; }

        /// <summary>
        ///     Cidade onde encontra-se o bairro.
        /// </summary>
        [XmlIgnore]
        public virtual EnderecoCidade Cidade { get; set; }

        /// <summary>
        ///     Lista de endereços que estão contidos no bairro.
        /// </summary>
        [XmlIgnore]
        public virtual IList<Endereco> Enderecos { get; set; }
    }

    /// <summary>
    ///     Classe que mapeia o arquivo XML de bairro.
    /// </summary>
    [Serializable]
    [XmlRoot("ColecaoBairros")]
    public class ColecaoBairros
    {
        /// <summary>
        ///     Propriedade que guarda a lista de bairros contida no arquivo XML de bairros.
        /// </summary>
        [XmlArray("Bairros")]
        [XmlArrayItem("Bairro", typeof (EnderecoBairro))]
        public List<EnderecoBairro> Bairro { get; set; }
    }
}