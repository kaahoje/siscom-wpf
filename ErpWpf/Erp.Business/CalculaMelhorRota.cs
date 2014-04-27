using System;
using System.Xml.Linq;

namespace Erp.Business
{
    class CalculaMelhorRota
    {
        public void MelhorRota(string origemLogradouroCliente, string origemCidadeCliente, string destinoLogradouroCliente, string destinoCidadeCliente, string[] proprietarios)
        {
            var origem = string.Format("{0} {1}", origemLogradouroCliente, origemCidadeCliente);

            var destino = string.Format("{0} {1}", destinoLogradouroCliente, destinoCidadeCliente);

            //URL do distancematrix - adicionando endereço de origem e destino
            var url = string.Format("http://maps.googleapis.com/maps/api/distancematrix/xml?origins={0}&destinations={1}&mode=driving&language=pt-BR&sensor=false", origem, destino);

            //Carregar o XML via URL
            var xml = XElement.Load(url);

            //Verificar se o status é OK
            var xElement = xml.Element("status");

            var enderecoOrigem = string.Empty;

            var enderecoDestino = string.Empty;
            
            var duracao = string.Empty;
            
            var distancia = string.Empty;

            var erro = string.Empty;


            if (xElement != null && xElement.Value == "OK")
            {
                var element = xml.Element("origin_address");

                if (element != null)
                {
                    enderecoOrigem = element.Value;
                }


                var xElement1 = xml.Element("destination_address");

                if (xElement1 != null)
                {
                    enderecoDestino = xElement1.Value;
                }


                var xmlRow = xml.Element("row");

                if (xmlRow != null)
                {
                    var xmlElement = xmlRow.Element("element");

                    if (xmlElement != null)
                    {
                        var xmlDistance = xmlElement.Element("distance");

                        var xmlDuration = xmlElement.Element("duration");

                        if (xmlDuration != null && xmlDistance != null)
                        {
                            var xmlTextDistance = xmlDistance.Element("text");

                            var xmlTextDuration = xmlDuration.Element("text");

                            if (xmlTextDuration != null && xmlTextDistance != null)
                            {
                                duracao = xmlTextDuration.Value;

                                distancia = xmlTextDistance.Value;
                            }
                        }
                    }
                }

            }
            else
            {
                //Se ocorrer algum erro
                var xmlStatus = xml.Element("status");
                if (xmlStatus != null)
                {
                    erro = String.Concat("Ocorreu o seguinte erro: ", xmlStatus.Value);
                }
            }
        }


    }
}
