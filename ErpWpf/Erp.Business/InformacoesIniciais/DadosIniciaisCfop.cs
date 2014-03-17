using System;
using System.IO;
using Erp.Business.Entity.Fiscal.ClassesRelacionadas;
using NHibernate;

namespace Erp.Business.InformacoesIniciais
{
    public class DadosIniciaisCfop
    {
        public static void Iniciar(ISession s)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "arquivos\\";
                var arqCfop = new StreamReader(path + "cfop.txt");
                string line = "";
                while (line != null)
                {
                    line = arqCfop.ReadLine();
                    if (line != null)
                    {
                        string[] split = line.Split(';');
                        var cfop = new Cfop
                        {
                            CodigoCfop = int.Parse(split[0]),
                            Aplicacao = split[1]
                        };
                        s.Save(cfop);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao importar a tabela CFOP.\n" + ex.Message);
            }
        }
    }
}