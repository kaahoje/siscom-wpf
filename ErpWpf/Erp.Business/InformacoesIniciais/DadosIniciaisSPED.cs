using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Erp.Business.Entity.Sped;
using Erp.Business.Enum;
using Erp.Business.InformacoesIniciais.MapeamentoXML;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisSped
    {
        private static readonly Dictionary<string, Conta> chavesExistentes = new Dictionary<string, Conta>();

        public static void PlanoContaReferencial(ISession session)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "arquivos\\";
                var serializer = new XmlSerializer(typeof (PlanoContaReferencialXml));
                string arquivo = path + "plano_conta.xml";
                var reader = new StreamReader(arquivo);
                List<Conta> contas = ((PlanoContaReferencialXml) serializer.Deserialize(reader)).Contas;
                reader.Close();

                foreach (Conta conta in contas)
                {
                    if (!chavesExistentes.ContainsKey(conta.Codigo) && conta.DataValidade.Equals(""))
                    {
                        using (var ct = new PlanoContaReferencial())
                        {
                            ct.Codigo = conta.Codigo;
                            ct.Descricao = conta.Descricao;
                            string sCod = "0";
                            if (conta.Codigo.Contains("."))
                            {
                                sCod = conta.Codigo.Substring(0,
                                    conta.Codigo.IndexOf(".", StringComparison.Ordinal));
                            }
                            else
                            {
                                sCod = conta.Codigo;
                            }
                            int cod = int.Parse(sCod);
                            switch (cod)
                            {
                                case 1:
                                    ct.NaturezaConta = NaturezaConta.Ativo;
                                    break;
                                case 2:
                                    ct.NaturezaConta = NaturezaConta.Passivo;
                                    break;
                                case 3:
                                    ct.NaturezaConta = NaturezaConta.ResultadoLiquido;
                                    break;
                                case 4:
                                    ct.NaturezaConta = NaturezaConta.SuperavitDeficit;
                                    break;
                                case 5:
                                    ct.NaturezaConta = NaturezaConta.CustosProducao;
                                    break;
                                default:
                                    ct.NaturezaConta = NaturezaConta.Outras;
                                    break;
                            }
                            session.Save(ct);
                            chavesExistentes.Add(ct.Codigo, conta);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Não foi possível carregar o plano de contas referêncial para o " +
                                "banco de dados.\n Erro: " + exception.Message);

                throw;
            }
        }
    }
}