using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que define a estrutura de uma cidade.
    /// </summary>
    [Serializable]
    public class EnderecoCidade
    {
        /// <summary>
        ///     Construtor de classe.
        /// </summary>
        public EnderecoCidade()
        {
            Enderecos = new List<PessoaEndereco>();
            Bairros = new List<EnderecoBairro>();
        }

        /// <summary>
        ///     Propriedade que define o identificador de uma cidade.
        /// </summary>
        [XmlElement("Id")]
        public virtual int Id { get; set; }

        /// <summary>
        ///     Nome da cidade.
        /// </summary>
        [XmlElement("Nome")]
        public virtual string Nome { get; set; }

        /// <summary>
        ///     Código IBGE do município.
        /// </summary>
        [XmlElement("CodigoIBGE")]
        public virtual int CodigoIBGE { get; set; }

        /// <summary>
        ///     Area em metros quadrados do município.
        /// </summary>
        [XmlElement("Area")]
        public virtual string Area { get; set; }

        /// <summary>
        ///     mapeia o campo para o arquivo xml de estados.
        /// </summary>
        [XmlElement("Estado_id")]
        public virtual int Estado_Id { get; set; }

        /// <summary>
        ///     Referência à um estado da federeção.
        /// </summary>
        [XmlIgnore]
        public virtual EnderecoEstado Estado { get; set; }

        /// <summary>
        ///     Lista de endereços contidos na cidade.
        /// </summary>
        [XmlIgnore]
        public virtual IList<PessoaEndereco> Enderecos { get; set; }

        /// <summary>
        ///     Lista dos bairros contidos na cidade.
        /// </summary>
        [XmlIgnore]
        public virtual IList<EnderecoBairro> Bairros { get; set; }
    }

    /// <summary>
    ///     Classe que mapeia o arquivo XML de cidades.
    /// </summary>
    [Serializable]
    [XmlRoot("ColecaoCidades")]
    public class ColecaoCidades
    {
        /// <summary>
        ///     Lista de cidades contidas no arquivo XML de cidades.
        /// </summary>
        [XmlArray("Cidades")]
        [XmlArrayItem("Cidade", typeof (EnderecoCidade))]
        public List<EnderecoCidade> Cidade { get; set; }
    }
}