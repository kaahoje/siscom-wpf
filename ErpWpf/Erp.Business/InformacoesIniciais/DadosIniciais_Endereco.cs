using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Npgsql;

namespace Erp.Business.InformacoesIniciais
{
    /// <summary>
    ///     Tabela que insere os endereços possíveis no banco de dados.
    /// </summary>
    public class DadosIniciaisEndereco
    {
        private static List<EnderecoEstado> _estados;
        private static List<EnderecoCidade> _cidades;
        private static List<EnderecoBairro> _bairros;

        /// <summary>
        ///     Método que carrega os endereços do arquivo xml de endereços e insere os mesmos na tabela de
        ///     endereços.
        /// </summary>
        public static void SaveEndereco()
        {
            var sbEstado = new StringBuilder();
            var sbCidade = new StringBuilder();
            var sbBairro = new StringBuilder();
            var sbEndereco = new StringBuilder();

            const int enderecoCount = 50000; //caso de out of memory diminuir a quantidade;

            //PAIS
            string[] listCountryText = GetListPais();
            //EnderecoPaisRepository.Session = session;
            //EnderecoBairroRepository.Session = session;
            //EnderecoCidadeRepository.Session = session;
            //EnderecoCidadeRepository.Session = session; 
            foreach (string t in listCountryText)
            {
                EnderecoPaisRepository.Save(new EnderecoPais {Nome = t.Trim()});
            }

            using (
                var conn =
                    new NpgsqlConnection(
                        EnderecoPaisRepository.GetSessionFactory().OpenSession().Connection.ConnectionString))
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string path = AppDomain.CurrentDomain.BaseDirectory + "arquivos\\";
                try
                {
                    //ESTADO
                    const string fileEstado = @"\Xml_Estado.xml";
                    string pathEstdo = path + fileEstado;

                    var serializer = new XmlSerializer(typeof (ColecaoEstados));
                    var reader = new StreamReader(pathEstdo);
                    _estados = ((ColecaoEstados) serializer.Deserialize(reader)).Estado;
                    reader.Close();

                    sbEstado.Append("INSERT INTO \"EnderecoEstado\" (id, nome, uf,pais_id)VALUES");
                    EnderecoPais paisBrasil = EnderecoPaisRepository.GetPaisByName("Brasil");
                    foreach (EnderecoEstado estado in _estados)
                    {
                        sbEstado.Append("('" + estado.Id + "',$$"
                                        + Utils.RemoveCaracteresEspeciais(estado.Nome)
                                        + "$$,'" + estado.UF + "',$$" + paisBrasil.Id + "$$),");
                    }

                    sbEstado = sbEstado.Remove(sbEstado.Length - 1, 1);

                    var cmdEstado = new NpgsqlCommand(sbEstado.ToString(), conn);
                    cmdEstado.ExecuteNonQuery();

                    //CIDADE
                    const string fileCidade = @"\Xml_Cidade.xml";
                    string pathCidade = path + fileCidade;

                    serializer = new XmlSerializer(typeof (ColecaoCidades));

                    reader = new StreamReader(pathCidade);
                    _cidades = ((ColecaoCidades) serializer.Deserialize(reader)).Cidade;

                    reader.Close();


                    sbCidade.Append("INSERT INTO \"EnderecoCidade\" (id, nome, codigoibge, area, estado_id)VALUES");

                    foreach (EnderecoCidade cidade in _cidades)
                    {
                        sbCidade.Append("('" + cidade.Id + "',$$" +
                                        Utils.RemoveCaracteresEspeciais(cidade.Nome) + "$$,'" + cidade.CodigoIBGE +
                                        "','" +
                                        cidade.Area
                                        + "','" + cidade.Estado_Id + "'),");
                    }

                    sbCidade = sbCidade.Remove(sbCidade.Length - 1, 1);

                    var cmdCidade = new NpgsqlCommand(sbCidade.ToString(), conn);
                    cmdCidade.ExecuteNonQuery();

                    //BAIRRO
                    const string fileBairro = @"\Xml_Bairro.xml";
                    string pathBairro = path + fileBairro;

                    serializer = new XmlSerializer(typeof (ColecaoBairros));

                    reader = new StreamReader(pathBairro);
                    _bairros = ((ColecaoBairros) serializer.Deserialize(reader)).Bairro;

                    reader.Close();

                    sbBairro.Append("INSERT INTO \"EnderecoBairro\"(id, nome, cidade_id) VALUES");

                    foreach (EnderecoBairro bairro in _bairros)
                    {
                        sbBairro.Append("('" + bairro.Id + "',$$" + Utils.RemoveCaracteresEspeciais(bairro.Nome) +
                                        "$$,'" + bairro.Cidade_Id + "'),");
                    }

                    sbBairro = sbBairro.Remove(sbBairro.Length - 1, 1);

                    var cmbBairro = new NpgsqlCommand(sbBairro.ToString(), conn);
                    cmbBairro.ExecuteNonQuery();

                    //ENDERECO
                    const string fileEndereco = @"\Xml_Endereco.xml";
                    string pathEndereco = path + fileEndereco;

                    serializer = new XmlSerializer(typeof (ColecaoEnderecos));

                    reader = new StreamReader(pathEndereco);
                    List<Endereco> enderecos = ((ColecaoEnderecos) serializer.Deserialize(reader)).Endereco;
                    reader.Close();

                    bool inicio = true;

                    for (int i = 0; i < enderecos.Count; i++)
                    {
                        Endereco endereco = enderecos[i];

                        if (inicio)
                        {
                            sbEndereco.Append("INSERT INTO \"Endereco\" (id, nome, cep, cidade_id, bairro_id)VALUES");
                            inicio = false;
                        }

                        if (endereco.Bairro_Id != 0)
                        {
                            sbEndereco.Append("('" + endereco.Id + "',$$" + Utils.RemoveCaracteresEspeciais(
                                endereco.Nome) + "$$,'" + endereco.Cep + "','" +
                                              endereco.Cidade_Id + "', '" + endereco.Bairro_Id + "'),");
                        }
                        else
                        {
                            sbEndereco.Append("('" + endereco.Id + "',$$" +
                                              Utils.RemoveCaracteresEspeciais(endereco.Nome) + "$$,'" + endereco.Cep +
                                              "','" +
                                              endereco.Cidade_Id + "', null),");
                        }


                        if (i <= 1 || i%enderecoCount != 0) continue;
                        sbEndereco = sbEndereco.Remove(sbEndereco.Length - 1, 1);
                        var cmdEndereco = new NpgsqlCommand(sbEndereco.ToString(), conn);
                        cmdEndereco.ExecuteNonQuery();
                        sbEndereco = new StringBuilder();
                        inicio = true;
                    }

                    sbEndereco = sbEndereco.Remove(sbEndereco.Length - 1, 1);
                    var cmdEnderecoRestante = new NpgsqlCommand(sbEndereco.ToString(), conn);
                    cmdEnderecoRestante.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("ERRO AO INSERIR DadosIniciais_Endereco. Mensagem = " + ex.Message);
                }
            }
        }

        public static string[] GetListPais()
        {
            string listPais =
                Utils.RemoveCaracteresEspeciais(
                    "Afeganistão,África do Sul, Akrotiri, Albânia, Alemanha, Andorra, Angola, Anguila, Antárctida, Antígua e Barbuda, Antilhas Neerlandesas," +
                    "Arábia Saudita, Arctic Ocean, Argélia, Argentina, Arménia, Aruba, Ashmore and Cartier Islands, Atlantic Ocean," +
                    "Austrália, Áustria, Azerbaijão, Baamas, Bangladeche, Barbados, Barém, Bélgica, Belize, Benim, Bermudas, Bielorrússia," +
                    "Birmânia, Bolívia,Bósnia e Herzegovina, Botsuana, Brasil, Brunei, Bulgária, Burquina Faso, Burúndi, Butão, Cabo Verde, Camarões," +
                    " Camboja, Canadá, Catar, Cazaquistão, Chade, Chile, China, Chipre, Clipperton Island, Colômbia, Comores, Congo,Brazzaville," +
                    "Congo,Kinshasa, Coral Sea Islands, Coreia do Norte, Coreia do Sul,Costa do Marfim, Costa Rica, Croácia, Cuba, Dhekelia, Dinamarca, " +
                    "Domínica, Egipto, Emiratos Árabes Unidos, Equador, Eritreia, Eslováquia, Eslovénia, Espanha, Estados Unidos, Estónia, Etiópia, Faroé," +
                    " Fiji, Filipinas, Finlândia, França, Gabão, Gâmbia, Gana, Gaza Strip, Geórgia, Geórgia do Sul e Sandwich do Sul," +
                    "Gibraltar, Granada, Grécia, Gronelândia, Guame, Guatemala, Guernsey, Guiana, Guiné, Guiné Equatorial, Guiné,Bissau, Haiti, " +
                    "Honduras, Hong Kong, Hungria, Iémen, Ilha Bouvet, Ilha do Natal, Ilha Norfolk, Ilhas Caimão, Ilhas Cook, Ilhas dos Cocos, " +
                    "Ilhas Falkland, Ilhas Heard e McDonald, Ilhas Marshall, Ilhas Salomão, Ilhas Turcas e Caicos," +
                    "Ilhas Virgens Americanas, Ilhas Virgens Britânicas, Índia, Indian Ocean, Indonésia, Irão, Iraque, Irlanda, Islândia, Israel," +
                    " Itália, Jamaica, Jan Mayen, Japão, Jersey, Jibuti, Jordânia, Kuwait, Laos, Lesoto, Letónia, Líbano, Libéria, Líbia, Listenstaine, " +
                    "Lituânia, Luxemburgo, Macau, Macedónia, Madagáscar, Malásia, Malávi, Maldivas, Mali," +
                    "Malta, Man, Isle of, Marianas do Norte, Marrocos, Maurícia, Mauritânia, Mayotte, México, Micronésia, Moçambique, Moldávia, Mónaco," +
                    " Mongólia, Monserrate, Montenegro, Mundo, Namíbia, Nauru, Navassa Island, Nepal, Nicarágua, Níger, Nigéria, Niue, Noruega, Nova Caledónia," +
                    " Nova Zelândia, Omã, Pacific Ocean, Países Baixos, Palau, Panamá, Papua,Nova Guiné," +
                    "Paquistão, Paracel Islands, Paraguai, Peru, Pitcairn, Polinésia Francesa, Polónia, Porto Rico, Portugal, Quénia, Quirguizistão, Quiribáti, " +
                    "Reino Unido, República Centro,Africana, República Checa, República Dominicana, Roménia, Ruanda, Rússia, Salvador, Samoa, Samoa Americana, Santa Helena," +
                    " Santa Lúcia, São Cristóvão e Neves, São Marinho," +
                    "São Pedro e Miquelon, São Tomé e Príncipe, São Vicente e Granadinas, Sara Ocidental, Seicheles, Senegal, Serra Leoa, Sérvia, Singapura, Síria, Somália, " +
                    "Southern Ocean, Spratly Islands, Sri Lanca, Suazilândia, Sudão, Suécia, Suíça, Suriname, Svalbard e Jan Mayen, Tailândia, Taiwan, Tajiquistão, Tanzânia, " +
                    "Território Britânico do Oceano Índico," +
                    "Territórios Austrais Franceses, Timor Leste, Togo, Tokelau, Tonga, Trindade e Tobago, Tunísia, Turquemenistão, Turquia, Tuvalu, Ucrânia, Uganda," +
                    " União Europeia, Uruguai, Usbequistão, Vanuatu, Vaticano, Venezuela, Vietname, Wake Island, Wallis e Futuna, West Bank, Zâmbia, Zimbabué");

            return listPais.Split(',');
        }
    }
}