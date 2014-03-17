using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Erp.Business.InformacoesIniciais.MapeamentoXML
{
    [Serializable]
    [XmlRoot("PlanoContaReferencial")]
    public class PlanoContaReferencialXml
    {
        public PlanoContaReferencialXml()
        {
            Contas = new List<Conta>();
        }

        [XmlArray("Contas")]
        [XmlArrayItem("Conta", typeof (Conta))]
        public List<Conta> Contas { get; set; }
    }

    [Serializable]
    public class Conta
    {
        [XmlElement("codigo")]
        public string Codigo { get; set; }

        [XmlElement("descricao")]
        public string Descricao { get; set; }

        [XmlElement("datainicio")]
        public string DataInicio { get; set; }

        [XmlElement("datavalidade")]
        public string DataValidade { get; set; }

        [XmlElement("tipo")]
        public string Tipo { get; set; }

        [XmlElement("pai")]
        public string Pai { get; set; }

        [XmlElement("nivel")]
        public string Nivel { get; set; }
    }
}