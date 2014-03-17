using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas.Endereco;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisNcm
    {
        private static int idTribEstado = 294895;
        private static int idTribServico = 116428521;
        public static int id = 1;
        private static int idTributacao = 1;
        public static string NcmInicial = "";
        private static Ncm _NcmPadraoProduto;
        private static IList<EnderecoEstado> Estados;
        public static bool GerarArquivo { get; set; }

        public static Ncm NcmPadraoProduto
        {
            get { return _NcmPadraoProduto; }
        }

        public static void IniciarDados(ISession session)
        {
            var buf = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "arquivos\\IBPTax.csv");
            //var session = NcmRepository.GetSessionFactory().OpenSession().Connection;
            string conteudoArquivo = "";


            string currentLine = "";
            Estados = EnderecoEstadoRepository.GetList();
            try
            {
                while (currentLine != null)
                {
                    currentLine = buf.ReadLine();

                    if (currentLine != null)
                    {
                        string[] line = currentLine.Split(';');
                        if (line[6].Equals(""))
                        {
                            string novoNcm = "INSERT INTO \"Ncm\"(" +
                                             "id, " +
                                             "codigo, " +
                                             "descricao, " +
                                             "tributosnacionalibpt, " +
                                             "tributosimportadoibpt, " +
                                             "excessaofiscal, " +
                                             "tabela) " +
                                             "VALUES (" +
                                             id + ", " +
                                             line[0] + ", '" +
                                             Utils.RemoveCaracteresEspeciais(line[3]) + "', " +
                                             line[4].Replace(",", ".") + ", " + // Tributos nacionais
                                             line[5].Replace(",", ".") + ", '" + // Tributos importados
                                             line[1] + "', " +
                                             line[2] + ");";
                            //string novaTributacao = GeraTributacao(id);
                            if (GerarArquivo)
                            {
                                //conteudoArquivo += novaTributacao + novoNcm;
                                conteudoArquivo += novoNcm;
                            }
                            else
                            {
                                IDbCommand cmd = session.Connection.CreateCommand();
                                //cmd.CommandText = novaTributacao;
                                //cmd.ExecuteNonQuery();
                                cmd.CommandText = novoNcm;
                                cmd.ExecuteNonQuery();
                            }

                            //var ncm = new Ncm()
                            //   {
                            //       Codigo = line[0],
                            //       ExcessaoFiscal = line[1],
                            //       Tabela = int.Parse(line[2]),
                            //       Descricao = Utils.RemoveCaracteresEspeciais(line[3]),
                            //       TributosNacionalIbpt = decimal.Parse(),
                            //       TributosImportadoIbpt = decimal.Parse(),
                            //       Tributacao = new Tributacao()
                            //   };
                            //ncm = MontaTributacao(ncm);
                            //foreach (var tribEst in ncm.Tributacao.TributacaoEstado)
                            //{
                            //    foreach (var s in tribEst.TributacaoServicos)
                            //    {
                            //        session.Save(s);
                            //    }
                            //    session.Save(tribEst);
                            //}
                            //session.Save(ncm);
                            //if (ncm.Codigo.Equals("01012900"))
                            //{
                            //    _NcmPadraoProduto = ncm;
                            //}
                        }

                        id += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao importar dados do arquivo IBPTTax.");
            }


            if (GerarArquivo)
            {
                if (!conteudoArquivo.Equals(""))
                {
                    Utils.GravarArquivo(Environment.CurrentDirectory +
                                        "\\ncms.sql", conteudoArquivo);
                }
            }
        }

        private static string GeraTributacao(int ncm)
        {
            string ret = "INSERT INTO \"Tributacao\"(id)" +
                         "VALUES (" + ncm + ");";

            //if (Estados == null)
            //{
            //    Estados = EnderecoEstadoRepository.GetList();
            //}

            foreach (EnderecoEstado estado in Estados)
            {
                string tribEstado = "INSERT INTO \"TributacaoNcmEstado\"(" +
                                    "id, " +
                                    "icmsdevedor, " +
                                    "opercaonotadagente, " +
                                    "tipotributacaoicms, " +
                                    "estado_id, " +
                                    "tributacao_ncm_id" +
                                    ")VALUES (" +
                                    idTribEstado + ", " +
                                    0 + ", " +
                                    (int) OperacaoNotaDaGente.Venda + ", " +
                                    (int) SituacaoTributaria.Tributado + ", " +
                                    estado.Id + ", " +
                                    ncm + ");";
                ret += tribEstado;
                //foreach (var cidade in estado.Cidades)
                //{
                //    var tribServico = "INSERT INTO \"TributacaoNcmServicoMunicipio\"(" +
                //                      "id, " +
                //                      "issdevedor, " +
                //                      "tipotributacaoiss, " +
                //                      "municipio_id, " +
                //                      "tributacao_ncm_estado_id)" +
                //                      "VALUES (" +
                //                      idTribServico + ", " +
                //                      0 + ", " +
                //                      (int)SituacaoTributaria.Tributado + ", " +
                //                      cidade.Id + ", " +
                //                      idTribEstado + ");";
                //    ret += tribServico;
                //    idTribServico += 1;
                //}
                idTribEstado += 1;
            }
            return ret;
        }
    }
}