using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco
{
    /// <summary>
    ///     Classe que define a estrutrura de um endereço.
    /// </summary>
    [Serializable]
    public class Endereco
    {
        /// <summary>
        ///     Campo identificador do endereço
        /// </summary>
        [XmlElement("Id")]
        public virtual int Id { get; set; }

        /// <summary>
        ///     CEP do endereço.
        /// </summary>
        [XmlElement("Cep")]
        public virtual string Cep { get; set; }

        /// <summary>
        ///     Logradouro(Ex: Rua Camerindo, Avenida 7)
        /// </summary>
        [XmlElement("Nome")]
        public virtual string Nome { get; set; }

        /// <summary>
        ///     Código município de acordo com a tabela dispoível no site do IBGE.
        ///     Este campo tem por finalidade mapeiar o campo do arquvo xml que contém
        ///     o identificador da cidade.
        /// </summary>
        [XmlElement("Cidade_id")]
        public virtual int Cidade_Id { get; set; }

        /// <summary>
        ///     Cidade onde o se encontra o endereço.
        /// </summary>
        public virtual EnderecoCidade Cidade { get; set; }

        /// <summary>
        ///     Campo que mapeia o identificador do bairro no arquivo XML de bairros.
        /// </summary>
        [XmlElement("Bairro_id")]
        public virtual int Bairro_Id { get; set; }

        /// <summary>
        ///     Bairro onde o endereço se encontra..
        /// </summary>
        [XmlIgnore]
        public virtual EnderecoBairro Bairro { get; set; }
    }

    /// <summary>
    ///     Classe que mapeia o arquivo XML de endereços.
    /// </summary>
    [Serializable]
    [XmlRoot("ColecaoEnderecos")]
    public class ColecaoEnderecos
    {
        /// <summary>
        ///     mapeia uma lista de endereços com base no formato do arquivo xml.
        /// </summary>
        [XmlArray("Enderecos")]
        [XmlArrayItem("Endereco", typeof (Endereco))]
        public List<Endereco> Endereco { get; set; }
    }
}